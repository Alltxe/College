import json
import random


def get_user_input():
    """Ввод данных с консоли"""
    print("Введите предпочтения:")
    genre = input("Жанр (триллер, комедия, анимация): ")
    platform = input("Платформа (Netflix, Disney+, Prime Video): ")
    mood = input("Ваше настроение (позитивный/нейтральное/грустное): ")
    year = int(input("Год после которого (например, 2020): "))
    rating = float(input("Минимальный рейтинг (0-10): "))
    return {
        "genre": genre,
        "platform": platform,
        "mood": mood,
        "year": year,
        "rating": rating,
    }


def load_rules(file_path):
    try:
        with open(file_path, 'r', encoding='utf-8') as file:
            return json.load(file)
    except Exception as e:
        print(e)
        return []



def apply_rules(facts, rules):
    recommendations = []
    for rule in rules:
        if eval(rule["condition"], {}, facts):
            if "options" in rule:
                # Выбор действия по весам
                total = sum(opt["weight"] for opt in rule["options"])
                rand = random.uniform(0, total)
                current = 0.0
                for opt in rule["options"]:
                    current += opt["weight"]
                    if rand <= current:
                        recommendations.append(opt["action"])
                        break
            else:
                recommendations.append(rule["action"])
    return recommendations


def main():
    facts = get_user_input()
    rules = load_rules("rules.json")

    if not rules:
        print("Ошибка: Правила не загружены.")
        return

    recommendations = apply_rules(facts, rules)

    if recommendations:
        print("\nРекомендации:")
        for rec in recommendations:
            print(f"- {rec}")
    else:
        print("Нет подходящих рекомендаций.")


if __name__ == "__main__":
    main()