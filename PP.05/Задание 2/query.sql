SELECT 
    o.order_code AS "Код заказа",
    c.name AS "Заказчик",
    p.name AS "Продукция",
    oi.quantity AS "Количество продукции",

    oi.quantity * COALESCE(
        (SELECT pp.price 
         FROM product_price pp 
         WHERE pp.product_code = p.product_code 
         AND pp.valid_from <= o.date 
         AND (pp.valid_to IS NULL OR pp.valid_to >= o.date)
         ORDER BY pp.valid_from DESC 
         LIMIT 1),
        0
    ) AS "Стоимость продукции (руб)",
    
    oi.quantity * COALESCE(
        (SELECT SUM(sp.quantity * COALESCE(
            (SELECT mp.price 
             FROM material_price mp 
             WHERE mp.material_code = sp.material_code 
             AND mp.valid_from <= o.date 
             AND (mp.valid_to IS NULL OR mp.valid_to >= o.date)
             ORDER BY mp.valid_from DESC 
             LIMIT 1),
            0
        ))
         FROM specification sp 
         WHERE sp.product_code = p.product_code
        ),
        0
    ) AS "Стоимость материалов (руб)",
    
    (oi.quantity * COALESCE(
        (SELECT pp.price 
         FROM product_price pp 
         WHERE pp.product_code = p.product_code 
         AND pp.valid_from <= o.date 
         AND (pp.valid_to IS NULL OR pp.valid_to >= o.date)
         ORDER BY pp.valid_from DESC 
         LIMIT 1),
        0
    )) +
    (oi.quantity * COALESCE(
        (SELECT SUM(sp.quantity * COALESCE(
            (SELECT mp.price 
             FROM material_price mp 
             WHERE mp.material_code = sp.material_code 
             AND mp.valid_from <= o.date 
             AND (mp.valid_to IS NULL OR mp.valid_to >= o.date)
             ORDER BY mp.valid_from DESC 
             LIMIT 1),
            0
        ))
         FROM specification sp 
         WHERE sp.product_code = p.product_code
        ),
        0
    )) AS "Полная стоимость заказа (руб)"
    
FROM "order" o
JOIN customer c ON o.customer_code = c.customer_code
JOIN order_items oi ON o.order_code = oi.order_code
JOIN product p ON oi.product_code = p.product_code
WHERE o.order_code = 1
ORDER BY p.name;