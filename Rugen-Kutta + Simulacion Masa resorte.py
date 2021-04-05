import numpy as np
import matplotlib.pyplot as plt

#datos
m = 1
c = 0.2
k = 1

#condiciones iniciales
t = 0
xinc = 2
vinc = 0
u = np.array([xinc,vinc]) #vector de las condiones iniciales u0 y u1

def F(u,t):
    return np.array([u[1],-c*u[1]/m-k*u[0]/m])
    # return np.array([u[1],m-k*u[0]/m]) Aqui el modelo es ideal
#solucion
tsol = [t]
xsol=[u[0]]
vsol=[u[1]]
dt = 0.1 #Paso
tfin = 100 #Segundos

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

plt.plot(tsol,xsol)
plt.show()

#Grafico 3D 
from mpl_toolkits.mplot3d import axes3d
fig=plt.figure()
ax=fig.gca(projection='3d')
ax.plot(xsol,vsol,tsol)
plt.show()

#Animación
import matplotlib.animation as animation

fig = plt.figure()
ax = fig.gca()

def actualizar(i): #funcion encargada de actualizar el grafico para la animación
    ax.clear()
    plt.plot([0,xsol[i]],[0,0],"b-") #Construcción de la cuerda
    plt.plot(xsol[i],[0],"ro") #Construcción de la masa
    plt.title(str(round(tsol[i],2))) #Actualiza el tiempo de la simulación
    plt.xlim(min(xsol),max(xsol)) #Limite del grafico en X
    plt.ylim(-1,1) #Limite del grafico en Y
ani = animation.FuncAnimation(fig,actualizar,range(len(tsol)),repeat = False, interval =10)
plt.show()
#colocar en la consola %matplotlib auto