# Sesión 3: Introducción a JavaScript y Testing

## Fecha: 26/03/2025

## Objetivos de la Sesión

- Comprender los fundamentos de JavaScript moderno (ES6+)

## Temas Cubiertos

1. **Fundamentos de JavaScript**
   - Ejemplos de buenas prácticas con JS
   - Uso de Funciones (for, while, if, else if, else)


## Ejercicios Realizados

### Ejercicio 3: Uso de Funciones

```javascript

//Ejercicio 3: Crear una funcion que devuelva otra funcion que multiplica por un numero especifico
function multiplicador(factor){
    return function(numero){
        return numero * factor;
    }
}
const duplicar = multiplicador(2);
const triplicar = multiplicador(3);
const cuatriplicar = multiplicador(4);

console.log(duplicar(5));
console.log(triplicar(5));
console.log(cuatriplicar(5));

```


## Desafíos Encontrados

- **Sin impedimentos**: Por el momento no tuve ningun inconveniente al realizar la actividad. 

## Recursos Adicionales

- [JavaScript Testing Best Practices](https://github.com/goldbergyoni/javascript-testing-best-practices)
- [ES6 Features Overview](https://github.com/lukehoban/es6features)

## Próximos Pasos

- Continuar los avances en cursos de prerrequisitos. 
- Practicar los ejercicios realizados en la sesión.

## Reflexiones Personales

Esta sesión me ha ayudado a recordar conocimientos básicos sobre JavaScript, y lo funcional que es dentro de la programación.

---

*Entregable correspondiente a la Semana 2 del Módulo 1: JavaScript Testing*