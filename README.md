# ProyectoUnity
Mi juego es simplemente un juego de lucha por oleadas en el cual vendran enemigos de ambos lados y nosotros como jugador debemos atacar a la derecha o a la izquierda para derrotarles.
![alt text](https://github.com/ChristianSantamaria/ProyectoUnity/blob/master/FotosReadMe/Juego.PNG)


Los scripts digamos que los separe para mi facilidad, en ellos tenemos: en primero de todos el mas simple el MenuPrincipal ya que solo tiene una funcion que es ejecutada al pulsar el boton del boton de jugar

![alt text](https://github.com/ChristianSantamaria/ProyectoUnity/blob/master/FotosReadMe/M.PNG?raw=true)
![alt text](https://github.com/ChristianSantamaria/ProyectoUnity/blob/master/FotosReadMe/M2.PNG?raw=true)
El player es el script mas largo ya que tiene en el para que recoja todas las controles que son basicas A y D ataques normales y S y W para habilidades especiales que tengdran otro collider
![alt text](https://github.com/ChristianSantamaria/ProyectoUnity/blob/master/FotosReadMe/P.PNG?raw=true)

colliders(hitbox la caja invisible que esta rodeando al objeto y que se ejecuta al colisionar con otro objeto que en este caso con el tag de Zombie)

![alt text](https://github.com/ChristianSantamaria/ProyectoUnity/blob/master/FotosReadMe/P2.PNG?raw=true)

y el animator es el cual controlamos en que momento puede hacer dicha animacion, aqui por ejemplo empieza mirando hacia la derecha en el caso que se pulse A hara el ataque hacia la izquierda y se quedara mirando hacia alli y lo mismo para el tornado tras acabarlo seguira mirando para la posicion original
![alt text](https://github.com/ChristianSantamaria/ProyectoUnity/blob/master/FotosReadMe/P3.PNG?raw=true)


El Zombie (al principio los enemigos eran zombies) que basicamente es todo lo que tiene que hacer el enemigo tras el spawn(aparecer)
en mi caso hice que al llegar a cierta distancia tanto los de la derecha como los de la izquierda se frenaran y atacaran.

![alt text](https://github.com/ChristianSantamaria/ProyectoUnity/blob/master/FotosReadMe/Z.PNG?raw=true)

Aqui tengo una funcion que la uso simplemente para difenrenciar los zombies padres por llamarlos de algun modo de todos sus hijos y la otra que indica que cuando un zombie es atacado se pone en estado true hace la animacion de muerte y no puede ni atacar ni ser atacado 

![alt text](https://github.com/ChristianSantamaria/ProyectoUnity/blob/master/FotosReadMe/Z2.PNG?raw=true)

Y sus animaciones vienen siendo bastante simples correr, atacar y morir
![alt text](https://github.com/ChristianSantamaria/ProyectoUnity/blob/master/FotosReadMe/Z3.PNG?raw=true)

Y por ultimo script el SpawnZombies como antes dije de que habia unos zombies que eran los padres son asi porque de ellos se clonan todos los demas aleatoriamente se elige un numero cero o uno si es cero clona al de la izquierda y si es uno al de la derecha

![alt text](https://github.com/ChristianSantamaria/ProyectoUnity/blob/master/FotosReadMe/Spawn1.PNG?raw=true)
![alt text](https://github.com/ChristianSantamaria/ProyectoUnity/blob/master/FotosReadMe/Spawn.PNG?raw=true)


