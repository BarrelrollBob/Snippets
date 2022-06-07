import tkinter as tk

# ***************** DOESN'T DO ANYTHING *********************

# Top level window
frame = tk.Tk()
frame.title("TextBox Input")
frame.geometry('400x200')

def printInput():
    inp = inputtxt.get(1)
    lbl.config(text="Provided Input: " + inp)


# TextBox Creation
inputtxt = tk.Text(frame,
                   height=5,
                   width=20)

inputtxt.pack()

# Button Creation
printButton = tk.Button(frame,
                        text="Print",
                        command=printInput)
printButton.pack()

# Label Creation
lbl = tk.Label(frame, text="")
lbl.pack()
frame.mainloop()
