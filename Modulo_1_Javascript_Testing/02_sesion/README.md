# Sesión 2: Introducción a JavaScript y Testing

## Fecha: 25/03/2025

## Objetivos de la Sesión

- Comprender los fundamentos de JavaScript moderno (ES6+)

## Temas Cubiertos

1. **Fundamentos de JavaScript**
   - Uso de Variables (let, const)
   - Ejemplos de buenas prácticas con JS
   - Uso de Ciclos (for, while, if, else if, else)


## Ejercicios Realizados

### Ejercicio 2: Uso de Ciclos

```javascript

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

```


## Desafíos Encontrados

- **Sin impedimentos**: Por el momento no tuve ningun inconveniente al realizar la actividad. 

## Recursos Adicionales

- [JavaScript Testing Best Practices](https://github.com/goldbergyoni/javascript-testing-best-practices)
- [ES6 Features Overview](https://github.com/lukehoban/es6features)

## Próximos Pasos

- Revisar los cursos para prinicipiantes de JavaScript y practicar los ejercicios vistos en la sesíon.

## Reflexiones Personales

Esta sesión me ha ayudado a recordar conocimientos básicos sobre JavaScript, y lo funcional que es dentro de la programación.

---

*Entregable correspondiente a la Semana 2 del Módulo 1: JavaScript Testing*