# Sesión 1: Introducción a JavaScript y Testing

## Fecha: 24/03/2025

## Objetivos de la Sesión

- Comprender los fundamentos de JavaScript moderno (ES6+)

## Temas Cubiertos

1. **Fundamentos de JavaScript**
   - Uso de Variables
   - Ejemplos de buenas prácticas con JS


## Ejercicios Realizados

### Ejercicio 1: Calculadora con Tests

```javascript
// Sesion 1 - 24/03/2025

var int = 12345;
var string = "texto";
var boolean = true;

var nombre = "Lizeth";
var apellido = "Martinez";
var nombreCompleto = `${nombre} ${apellido}`;
var edad = 25;

console.log(`Bienvenido a mi aplicacion, soy ${nombreCompleto} y tengo ${edad} años.`)

//Comparación
// ==, ===, !=, <, >, >=, <=
var numero = "5";
var numeroTexto = 5;
console.error(numero == numeroTexto);
```


## Desafíos Encontrados

- **Configuración del entorno de Jest**: Tuve problemas iniciales con la configuración de Babel para usar sintaxis ES6. Lo resolví siguiendo la documentación oficial y ajustando el archivo `babel.config.js`.
- **Testing de excepciones**: Aprendí a usar correctamente la sintaxis para verificar que una función lanza excepciones específicas.

## Recursos Adicionales

- [JavaScript Testing Best Practices](https://github.com/goldbergyoni/javascript-testing-best-practices)
- [ES6 Features Overview](https://github.com/lukehoban/es6features)

## Próximos Pasos

- Revisar los cursos para prinicipiantes de JavaScript para la próxima sesión

## Reflexiones Personales

Esta sesión me ha ayudado a recordar conocimientos básicos sobre JavaScript, y lo funcional que es dentro de la programación.

---

*Entregable correspondiente a la Semana 2 del Módulo 1: JavaScript Testing*