import json

def load_data(file_path):
    try:
        with open(file_path, "r", encoding="utf-8") as f:
            data = json.load(f)
        return data
    except FileNotFoundError:
        print(f"Ошибка: файл {file_path} не найден.")
        return None
    except json.JSONDecodeError:
        print("Ошибка: неверный формат JSON.")
        return None

def recommend_place(user_preferences, restaurants):
    recommended_places = []
    for place in restaurants:
        if (place["type"] == user_preferences["type"] and
            place["cuisine"] == user_preferences["cuisine"] and
            place["rating"] == user_preferences["rating"]):
            recommended_places.append(place["name"])
    return recommended_places

if __name__ == "__main__":
    file_path = "restaurants.json"
    data = load_data(file_path)
    if not data:
        exit(1)

    restaurants = data.get("restaurants", [])

    print("Введите ваши предпочтения:")
    user_input = {
        "type": input("Тип заведения (Кафе, Ресторан, Фастфуд): ").strip(),
        "cuisine": input("Кухня (Итальянская, Французская, Русская): ").strip(),
        "rating": input("Рейтинг (Высокий, Средний, Низкий): ").strip()
    }

    recommendations = recommend_place(user_input, restaurants)

    if recommendations:
        print("\nРекомендуемые места:", recommendations)
    else:
        print("\nПодходящих заведений не найдено.")