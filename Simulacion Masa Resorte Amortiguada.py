import numpy as np
import matplotlib.pyplot as plt
import math
"""Desarrollado Por:
Alejandra Pedraza Cárdenas
Santiago Rodríguez Prada"""

#datos - Ingreso por teclado 
m = float(input("Ingrese el valor de la masa (Kg): "))
c = float(input("Ingrese el valor de la constante de amortiguamiento (Kg/s): "))
k = float(input("Ingrese el valor de la constante de elasticidad (N/m): "))

#condiciones iniciales  - Ingreso por teclado 
t1 = 0
t= 0
xinc = float(input("Ingrese la posición inicial (m): "))
vinc = 0
dt = float(input("Ingrese el tamaño del paso: "))
tfin = int(input("Ingrese hasta que seg quiere realizar la simulación: "))
u = np.array([xinc,vinc]) #vector de las condiones iniciales u0 y u1
u1 = np.array([xinc,vinc]) #vector de las condiones iniciales u0 y u1

def F(u,t):
    return np.array([u[1],-c*u[1]/m-k*u[0]/m])
    # return np.array([u[1],m-k*u[0]/m]) Aqui el modelo es ideal
tsol = [t]
xsol=[u[0]]
vsol=[u[1]]

def F1(u1,t1):
        return np.array([u1[1],-c*u1[1]/m-k*u1[0]/m]) # Retorna un vector con 2 valores
tsol2 = [t1]#Agregar condicion inicial al vector del tiempo 
x = [u1[0]] #Agregar condicion inicial al vector de la posición
v = [u1[1]] #Agregar condicion inicial al vector de la velocidad


#Solución Analitica

xanalitic = [] #Se crea una lita para almacenar las posiciones calculadas analiticamente
tiempoAnalitic = []
w = math.sqrt(k/m-(c/(2*m))**2) #Se calcula Omega
for i in np.arange (0,tfin+dt,dt):
    tiempoAnalitic.append(i)
    aux = math.exp(-0.1*i)*(0.201008*math.sin(0.994987*i)+2*math.cos(0.994987*i))
    xanalitic.append(aux) #Se calcula y se llena la lista para la solución analitica
plt.title("Solución Analitica")
plt.plot(tiempoAnalitic,xanalitic) 
plt.show() 


#Rugen Kuta
while t<tfin:
    k1=F(u,t)
    k2=F(u+dt*k1/2,t+dt/2)
    k3=F(u+dt*k2/2,t+dt/2)
    k4=F(u+dt*k3,t+dt)
    u = u +(k1+2*k2+2*k3+k4)*dt/6
    t = t+dt 
    xsol.append(u[0])
    vsol.append(u[1])
    tsol.append(t)
plt.title("Solución Runge-Kutta")
plt.plot(tsol,xsol)
plt.show()

#Solucion Euler

while t1<tfin:
    u1 = u1+F1(u1,t1)*dt #calculo de Yn+1
    t1 = t1+dt #Calculo de Xn+1
    x.append(u1[0]) #Llenar vector de la posición
    v.append(u1[1]) #Llenar vector de la velocidad
    tsol2.append(t1) #Llenar vector del tiempo
plt.title("Solución Euler")
plt.plot(tsol2,x) #Imprimir grafico de Tiempo vs Posición
plt.show() 

#Animación
import matplotlib.animation as animation

fig = plt.figure()
ax = fig.gca()

def actualizar(i): #funcion encargada de actualizar el grafico para la animación
    ax.clear()
    plt.plot([0,x[i]],[0,0],"b-") #Construcción de la cuerda
    plt.plot(x[i],[0],"ro") #Construcción de la masa
    plt.title(str(round(tsol2[i],2))) #Actualiza el tiempo de la simulación
    plt.xlim(min(x),max(x)) #Limite del grafico en X
    plt.ylim(-1,1) #Limite del grafico en Y
ani = animation.FuncAnimation(fig,actualizar,range(len(tsol2)),repeat = False, interval =40) #Animación
plt.show()