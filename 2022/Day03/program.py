from string import ascii_lowercase, ascii_uppercase

with open('input.txt', 'r') as file:
    rucksacks = file.readlines()
    points = {lett: i for i, lett in enumerate([*ascii_lowercase, *ascii_uppercase], start=1)}

    common1 = [
        list(set(items[:(len(items) // 2)]) & set(items[(len(items) // 2):]))[0]
        for items in rucksacks
    ]

    common2 = [
        list(set(elf1) & set(elf2) & set(elf3.replace('\n', '')))[0]
        for elf1, elf2, elf3 in zip(rucksacks[::3], rucksacks[1::3], rucksacks[2::3])
    ]

    print(f'Day 3, Part 1: {sum(map(points.get, common1))}')
    print(f'Day 3, Part 2: {sum(map(points.get, common2))}')
