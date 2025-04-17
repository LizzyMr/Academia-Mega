# Sesión 15: Introducción a JavaScript y Testing

## Fecha: 11/04/2025

## Objetivos de la Sesión

- Aplicar pruebas unitarias con Jest en JavaScript.

## Temas Cubiertos

1. **Fundamentos de TDD**
   - Instalación y configuración de Jest.
   - Escribir y ejecutar pruebas con Jest.

## Ejercicios Realizados

### Ejercicio 15: Pruebas con Jest - Capitalizar.



```js
//capitalizar.js
function capitalizar(palabra){
    return palabra.charAt(0).toUpperCase() + palabra.slice(1).toLowerCase();
}

module.exports = capitalizar
```

```js
//capitalizar.test.js
const capitalizar = require("./capitalizar");

test("capitalizar hola -> Hola", () =>{
    expect(capitalizar("hola")).toBe("Hola");
})

test("capitalizar JAVASCRIPT -> Javascript", () =>{
    expect(capitalizar("JAVASCRIPT")).toBe("Javascript");
})
```

## Desafíos Encontrados

- **Sin impedimentos:** Por el momento no tuve ningún inconveniente al realizar esta actividad.  

## Recursos Adicionales

- [JavaScript Testing Best Practices](https://github.com/goldbergyoni/javascript-testing-best-practices)
- [ES6 Features Overview](https://github.com/lukehoban/es6features)

## Próximos Pasos

- Continuar los avances en cursos de prerrequisitos. 
- Practicar los ejercicios realizados en la sesión.

## Reflexiones Personales

Esta sesión me ha ayudado a recordar conocimientos básicos sobre HTML, CSS y JS, y lo funcional que es dentro de la programación.

---

*Entregable correspondiente a la Semana 4 del Módulo 1: JavaScript Testing*