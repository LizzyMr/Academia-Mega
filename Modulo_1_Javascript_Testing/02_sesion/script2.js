//Anotaciones de la sesión 2
/*

//Ejemplo 1: 
var edad = 18;

if(edad<18){
    console.log("Eres menor de edad");
}else if(edad>= 18 && edad < 65){
    console.log("Eres un adulto");
}else{
    console.log("Eres un adulto mayor");
}


//Ejemplo 2:
let numero = prompt("Ingresa un numero: ");
numero = Number(numero)
if(numero > 0){
    console.log("El numero es positivo");
}else if(numero < 0){
    console.log("El numero es negativo");
}else{
    console.log("El numero es cero");
}


//Ejemplo 3:
for(let i = 1; i<=15; i++){
    console.log(`interacion numero ${i}` )
}

let contador = 1;
while (contador <=15){
    console.log(`Contador en ${contador}`)
    contador ++;
}
   
//Ejemplo 4:
let num= prompt("Ingresa un numero:");
num=Number(num);
if(num % 2 ===0){
    console.log("El numero es par");
}else{
    console.log("El numeri es impar");
}

//Ejemplo 5:
let suma = 0;
for(let i = 1; i<=100; i++){
    suma += i;
}
console.log("La suma del 1 al 100 es: ", suma)
*/

//Ejercicio 2: Uso de Ciclos
let intentos = 0;
let claveCorrecta = "1234";
let claveIngresada;

while(intentos <3){
    claveIngresada = prompt("Ingresa la contraseña:")

    if(claveIngresada === claveCorrecta){
        console.log("Acceso concedido.")
        break;
    }else{
        console.log("Acceso denegado. Contraseña incorrecta.");
    }
    intentos++;
}

if(intentos === 3){
    console.log("Has agotado tus intentos.");
}
