% Тип животного
animal_type(elephant, mammal).
animal_type(lion, mammal).
animal_type(snake, reptile).
animal_type(frog, amphibian).
animal_type(shark, fish).
animal_type(sparrow, bird).
animal_type(dolphin, mammal).
animal_type(crocodile, reptile).
animal_type(turtle, reptile).
animal_type(whale, mammal).

% Тип питания
diet(elephant, herbivore).
diet(lion, carnivore).
diet(snake, carnivore).
diet(frog, insectivore).
diet(shark, carnivore).
diet(sparrow, omnivore).
diet(dolphin, carnivore).
diet(crocodile, carnivore).
diet(turtle, herbivore).
diet(whale, planktivore).

% Место обитания
habitat(elephant, savanna).
habitat(lion, savanna).
habitat(snake, jungle).
habitat(frog, wetlands).
habitat(shark, ocean).
habitat(sparrow, forest).
habitat(dolphin, ocean).
habitat(crocodile, river).
habitat(turtle, ocean).
habitat(whale, ocean).

% Наличие хвоста
has_tail(elephant, true).
has_tail(lion, true).
has_tail(snake, true).
has_tail(frog, false).
has_tail(shark, true).
has_tail(sparrow, true).
has_tail(dolphin, true).
has_tail(crocodile, true).
has_tail(turtle, true).
has_tail(whale, true).

herbivores(X) :- diet(X, herbivore).

carnivores(X) :- diet(X, carnivore).

animals_with_tail(X) :- has_tail(X, true).

savanna_animals(X) :- habitat(X, savanna).

marine_animals(X) :- habitat(X, ocean).