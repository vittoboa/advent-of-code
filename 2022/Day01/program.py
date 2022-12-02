with open('input.txt', 'r') as file:
    elves_calories = file.read().split('\n\n')
    elves_tot_calories = [sum([int(cal) for cal in calories.split('\n')]) for calories in elves_calories]

    print(f'Day 1, Part 1: {max(elves_tot_calories)}')
    print(f'Day 1, Part 2: {sum(sorted(elves_tot_calories)[-3:])}')