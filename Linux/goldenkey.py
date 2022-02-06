import os
import random

class CheckPassword:
    def Check(self):
        uppercase = "ABCDEFGHIJKLMNOPQRSTUVWXYZ"
        lowercase = "abcdefghijklmnopqrstuvwxyz"
        numbers = "0123456789"
        symbols = "./^|*&?!@#()_+-="

        isUpper = False
        isLower = False
        isNumber = False
        isSymbol = False
        points = 0

        password = input("\n[+] Write your password: ")

        if len(password) >= 10 and len(password) <= 15:
            points += 1
        elif len(password) >= 15 and len(password) <= 20:
            points += 2
        elif len(password) >= 20:
            points += 3

        for i in range(len(uppercase)):
            if uppercase[i] in password:
                isUpper = True
            if lowercase[i] in password:
                isLower = True
        for i in range(len(numbers)):
            if numbers[i] in password:
                isNumber = True

        for i in range(len(symbols)):
            if symbols[i] in password:
                isSymbol = True
        
        if isUpper:
            points += 1
        if isLower:
            points += 1
        if isNumber:
            points += 1
        if isSymbol:
            points += 1

        print(f"+ Password Length: {len(password)}")
        print(f"+ Uppercase: {isUpper}")
        print(f"+ Lowercase: {isLower}")
        print(f"+ Number: {isNumber}")
        print(f"+ Symbol: {isSymbol}")

        print(f"\n[+] Result: {points} points")
        print("[+} Your password is ", end="")
        if points <= 3:
            print("too weak!")
        elif points > 3 and points < 5:
            print("average!")
        elif points >= 5 and points < 7:
            print("strong!")
        else:
            print("very strong!")

class GeneratePassword:
    def Generate(self):
        options = """
[01] Only letters
[02] Only numbers
[03] Only symbols
[04] Letters & numbers
[05] Symbols & numbers
[06] Letters & symbols
[07] All
[99] Exit

        """
        print(options)
        option = int(input("[+] Select option: "))
        length = int(input("[+] Password's length: "))

        letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz"
        numbers = "0123456789"
        symbols = "./^|*&?!@#()_+-="

        def RandomString(type, length):
            password = "".join(random.sample(type, length))
            return password

        def Show(type, length):
            for i in range(100):
                if i < 10:
                    print(f"[0{i}]--> " + RandomString(type, length))
                else: 
                    print(f"[{i}]--> " + RandomString(type, length))

        if option == 1:
            Show(letters, length)
        elif option == 2:
            Show(numbers, length)
        elif option == 3:
            Show(symbols, length)
        elif option == 4:
            Show(letters + numbers, length)
        elif option == 5:
            Show(symbols + numbers, length)
        elif option == 6:
            Show(letters + symbols, length)
        elif option == 7:
            Show(letters + numbers + symbols, length)
        elif option == 99:
            os.system("exit")
        else:
            GeneratePassword()

class GoldenKey:
    def Choice(self):
        while True:
            choice = int(input("\n[User]--> "))
            if choice == 1:
                gp = GeneratePassword()
                gp.Generate()
            elif choice == 2:
                cp = CheckPassword()
                cp.Check()
            elif choice == 99:
                break
            else:
                print("<!> Print number of option!")
                self.Choice()

    def Options(self):
        options = """
[01] Generate password
[02] Password strength
[..]        
[99] Exit     
"""
        print(options)
    
    def Title(self):
        version = "v.0.7.0"
        title = f"""
  _____       _     _            _  __          
 / ____|     | |   | |          | |/ /          
| |  __  ___ | | __| | ___ _ __ | ' / ___ _   _ 
| | |_ |/ _ \| |/ _` |/ _ \ '_ \|  < / _ \ | | |
| |__| | (_) | | (_| |  __/ | | | . \  __/ |_| |
 \_____|\___/|_|\__,_|\___|_| |_|_|\_\___|\__, |
                                           __/ |
                                          |___/ 
------------------------------------------------
Creator: AlexITDev, 2022 year
Version: GoldenKey {version}
------------------------------------------------
"""
        print(title)
        self.Options()
        self.Choice()

if "__main__" == __name__:
    gk = GoldenKey()
    gk.Title()
