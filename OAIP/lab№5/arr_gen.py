import random

f = open('long_arr.txt', 'w')

for i in range(10000):
    a = random.randint(1,1000);
    f.write(str(a) + '\n')
