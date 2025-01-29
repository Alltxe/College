import xml.etree.ElementTree as ET
import json
import random
from datetime import datetime
import matplotlib.pyplot as plt
import pandas as pd


def generate_last_12_months():
    today = datetime.today()
    current_year = today.year
    current_month = today.month
    months = []
    for i in range(12):
        year = current_year
        month = current_month - i
        if month <= 0:
            month += 12
            year -= 1
        months.append(f"{year}-{month:02d}")
    months.reverse()
    return months


def parse_xml(file_path):
    tree = ET.parse(file_path)
    root = tree.getroot()
    shop = root.find('shop')
    offers = shop.find('offers').findall('offer')

    models = []
    for offer in offers:
        model_id = offer.get('id')
        model_name = offer.find('name').text
        models.append({'id': model_id, 'name': model_name})
    return models


def generate_sales_data(models, months):
    sales_data = []
    for model in models:
        sales = []
        for month in months:
            sales.append({'month': month, 'sales': random.randint(0, 100)})
        sales_data.append({
            'model_id': model['id'],
            'model_name': model['name'],
            'sales': sales
        })
    return sales_data


def save_to_json(data, file_path):
    with open(file_path, 'w', encoding='utf-8') as f:
        json.dump(data, f, ensure_ascii=False, indent=4)


def visualize_sales(data):
    df_data = []
    for model in data:
        for sale in model['sales']:
            df_data.append({
                'Model': model['model_name'],
                'Month': sale['month'],
                'Sales': sale['sales']
            })
    df = pd.DataFrame(df_data)
    pivot_df = df.pivot(index='Month', columns='Model', values='Sales')

    plt.figure(figsize=(12, 6))
    for model in pivot_df.columns:
        plt.plot(pivot_df.index, pivot_df[model], marker='o', label=model)

    plt.title('Динамика продаж по месяцам')
    plt.xlabel('Месяц')
    plt.ylabel('Продажи')
    plt.xticks(rotation=45)
    plt.legend(bbox_to_anchor=(1.05, 1), loc='upper left')
    plt.tight_layout()
    plt.show()

    print("\nТаблица продаж:")
    print(pivot_df)


def main():
    # Настройки
    xml_file = 'couches.xml'  # Путь к XML файлу
    json_file = 'sales.json'  # Путь для сохранения JSON

    # Генерация данных
    months = generate_last_12_months()
    models = parse_xml(xml_file)
    sales_data = generate_sales_data(models, months)
    save_to_json(sales_data, json_file)

    # Визуализация
    visualize_sales(sales_data)


if __name__ == "__main__":
    main()