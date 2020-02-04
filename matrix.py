import sys

def main():
    conditions = {
        'a' : ['b','c'],
        'aa' : ['bb','cc','dd'],
        'aaa' : ['bbb','ccc'],
    }

    values = list(conditions.values())
    print(list(conditions.keys()))

    for line in get_lines(values):
        print(line)

def get_lines(values):
    rest = values[1:]
    if rest: 
        for item in values[0]:
            for u in get_lines(rest):
                yield [item] + u
    else:
        for item in values[0]:
            yield [item]



if __name__ == "__main__":
    main()