import numpy as np
from matplotlib import pyplot as plt

#Metodo de Euler
#Nombre: Andrés Santiago Rodríguez Prada
#Codigo: 6000363

def funcion(x,y): #En esta función se ingresa la dy/dx en la variable ecu
    ecu = (12*x**3)-(3*x**2)+(6*x)-3
    return ecu

def analitica(x,y): #En esta función se ingresa la ecuación en la variable ecu, esta ecuación es la solución analitica.
    ecu = (3*x**4)-(1*x**3)+(3*x**2)-(3*x)-983187
    return ecu

def Feuler(paso,x0,y0,x1): #Esta es la función que se encarga de calcular cada paso en el metodo de euler requiere como parametros el tamaño del paso, el x inicial, el y inicial y hasta que punto se calculara
    n = int((x1-x0)/paso)+1 #Se calcula cuantos espacioes en el vector se necesitan
    x = np.zeros(n) #Se crea vector para x
    y = np.zeros(n) #Se crea vector para y
    x[0] = x0 #Se asigna el valor inicial de x en el vector correspondiente
    y[0] = y0 #Se asigna el valor inicial de y en el vector correspondiente
    for i in np.arange(1,n): #Iteraciones para el calculo de Euler
        y[i] = y [i-1]+(funcion(x[i-1],y[i-1]))*paso
        x[i] = x[i-1]+paso
    return x,y

def Error(x,y): #Esta función calcula los errores correspondientes de cada punto de x
    n = len(x) 
    array = []
    print("El paso es " + str(abs(x[1]-x[0])))
    for i in np.arange(0,n): #Iteraciones para calcular los errores correspondientes
        num = analitica(x[i],y[i])
        aux = abs(y[i]-num)/num * 100 #Calculo de error
        array.append(aux)
        print("El error es " + str(round(aux,3))+" en el punto x = "+ str(round(x[i],3))) #Imprime en consola el error correspondiente al punto 'x'
        # print("y es: " +str(round(num,3))+ " y(euler) es : " + str(round(y[i],3))) -- Esta linea de codigo es opcional para ver en consola los valores de 'y' en el punto 'x' para ambos casos
    return array   

#Calculo de puntos iniciales, 6000abc mi codigo es 6000363 donde a = 3, b = 6, c = 3
a = 3
b = 6
c = 3
d = a + b +c
y0 = (a-b)*(d-c)
x0 = (a+b+c+d)
#El ingreso se hace por consola utilizando el teclado
h = float(input("Ingrese el primer tamaño de paso: "))
h1 = float(input("Ingrese el segundo tamaño de paso: "))
h2 = float(input("Ingrese el tercer tamaño de paso: "))
s = float(input("Ingrese valor final: "))

#Primer Euler
[x,y] = Feuler(h,x0,y0,s) #Llamado de función 

#Segundo Euler
[x1,y1] = Feuler(h1,x0,y0,s) #Llamado de función 

#Tercer Euñer
[x2,y2] = Feuler(h2,x0,y0,s) #Llamado de función 

#Metodo exacto

xe = np.arange(x0, s+0.1, 0.1) #INSTRUCCIONES PARA EL FOR
ye = []
for i in xe: #Ciclo de itreación para aumento de 'x' y calculo de 'y'
    ye.append(analitica(i,0))

#Calculo de errores
errores = Error(x,y)
errores2 = Error(x1,y1)
errores3 = Error(x2,y2)

#Graficación
plt.plot(xe,ye, 'r')
plt.scatter(x,y)
plt.scatter(x1,y1)
plt.scatter(x2,y2)
plt.show()
