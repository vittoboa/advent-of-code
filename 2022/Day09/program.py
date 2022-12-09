from numpy import sign
import dataclasses

# define a knot as a point in a two dimensional space
@dataclasses.dataclass
class Point:
    x: int = 0
    y: int = 0


def move_tail(curr_knot, prev_knot):
    # move current knot based on the position of the previous knot, according to the rules of the puzzle for Day9
    # the current knot may remain in its current position, or it may move horizontally, vertically or diagonally

    diff = Point(prev_knot.x - curr_knot.x, prev_knot.y - curr_knot.y)

    if diff.x == 0 or diff.y == 0:
        if abs(diff.x) == 2:
            # move horizontally
            curr_knot.x += sign(diff.x)
        elif abs(diff.y) == 2:
            # move vertically
            curr_knot.y += sign(diff.y)
    elif (abs(diff.x), abs(diff.y)) != (1,1):
        # move diagonally
        curr_knot.x += sign(diff.x)
        curr_knot.y += sign(diff.y)

    return curr_knot


with open('input.txt', 'r') as file:
    # define position movements based on direction
    movements = {'U': Point(0,1), 'D': Point(0,-1), 'R':Point(1,0), 'L':Point(-1,0)}

    # define sets to hold all positions of the selected knots, for part 1 and 2
    tail_positions1, tail_positions2 = set(), set()

    # init rope positions
    num_knots = 9
    head = Point()
    tails = [Point() for _ in range(num_knots)]

    # simulate series of motions
    for move in file.readlines():
        direction, amount = move.split()
        movement = movements[direction]

        # simulate positions of all knots of the rope after each motion
        for _ in range(int(amount)):
            # find new head positions
            head.x += movement.x
            head.y += movement.y

            # find new position for all knots of the tail
            for i in range(len(tails)):
                tails[i] = move_tail(tails[i], head if i == 0 else tails[i - 1])

            # store positions of the selected knots, for part 1 and 2
            tail_positions1.add(dataclasses.astuple(tails[0]))
            tail_positions2.add(dataclasses.astuple(tails[-1]))

    # print the number of all unique positions of the selected knots, for part 1 and 2
    print(f'Day 9, Part 1: {len(tail_positions1)}')
    print(f'Day 9, Part 2: {len(tail_positions2)}')
