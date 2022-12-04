with open('input.txt', 'r') as file:
    count1 = count2 = 0

    for assignments in file.readlines():
        range1, range2 = assignments.split(',')
        (s1, e1), (s2, e2) = range1.split('-'), range2.split('-')

        elf1 = range(int(s1), int(e1)+1)
        elf2 = range(int(s2), int(e2)+1)

        count1 += (all([num in elf2 for num in elf1]) or all([num in elf1 for num in elf2]))
        count2 += (any([num in elf2 for num in elf1]) or any([num in elf1 for num in elf2]))
    
    print(f'Day 4, Part 1: {count1}')
    print(f'Day 4, Part 2: {count2}')
