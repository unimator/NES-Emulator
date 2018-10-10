import sys

for i in range(0, 256):
	h = hex(i)
	h1 = h[0:2]
	h2 = h[2:4].upper()
	sys.stdout.write("Instructions[" + h1 + h2 + "] = new\n")

