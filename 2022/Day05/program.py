from copy import deepcopy
from collections import defaultdict

with open('input.txt', 'r') as file:
    stacks1 = defaultdict(list)

    # parse drawing to prepare stacks of crates
    while '1' not in (line := file.readline()):
        for i, create in enumerate(line.replace('\n', '').replace('    ', ' ').split(' ')):
            if len(create):
                stacks1[i + 1].insert(0, create.replace('[', '').replace(']', ''))

    # skip empty line
    file.readline()

    # create stack of cranes for part2
    stacks2 = deepcopy(stacks1)

    # move crates based on rearrangement procedures
    for line in file.readlines():
        # find rearrangement procedure
        num_cranes, source, dest = [int(x) for x in line.split() if x not in ['move', 'from', 'to']]

        # move crates
        stacks1[dest].extend([stacks1[source].pop() for _ in range(num_cranes)])
        stacks2[dest].extend(reversed([stacks2[source].pop() for _ in range(num_cranes)]))

    print(f'Day 5, Part 1: {"".join(nums[-1] for nums in dict(sorted(stacks1.items())).values())}')
    print(f'Day 5, Part 2: {"".join(nums[-1] for nums in dict(sorted(stacks2.items())).values())}')
