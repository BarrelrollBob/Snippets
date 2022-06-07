

def search_username(file, word):

    """
    Search a file for a search word.
    Function takes the word to be sought after and the file to search as string arguments and in the order [file, word].
    Any letter or number is fine. Lower and uppercase are differentiated, and the word can contain
    any of the following symbols: !@#$%?_-.
    """

    r = open(file, "r")
    counter = 0  # counter - need it to determine the starting index of a candidate range
    file_list = []  # file is perused and each index is appended to this list
    resolved_word = ''  # when a candidate range is found, the chars in the range are appended to this and checked
    the_range = ''

    for x in r.read():  # loop through file and append each index to file_list array
        if x.isnumeric() or x.isalpha() or x in ['!', '@', '#', '$', '%', '?', '_', '-', '.']:
            file_list.append(x)

    for x in file_list:  # loop through file list (why? can target indexes)

        the_range = f"{counter} - {counter + len(word) - 1}"

        if x == word[0]:  # if current index == first letter in word, do the following:

            start = counter  # start might be redundant - but I wanted to record in it the counter for current index
            print(f"Found a candidate in the {the_range} range for search word \"{word}\"")
            while True:

                resolved_word += file_list[start]
                print(resolved_word)

                if start == counter + len(word) - 1:
                    break

                start += 1

            if resolved_word == word:
                break

            elif resolved_word != word:
                resolved_word = ''
                print("Didn't match the search word. Commencing.")

        print(f"Nothing found at index {counter}.")
        counter += 1

    if resolved_word == '':
        print(f"The word \"{word}\" wasn't found in this context. Check your spelling.")
    else:
        print(f"The word \"{word}\" was found in the {the_range} range.")


search_username("testfile.txt", "billy@!$yoyobrr$$")
print(search_username.__doc__)
