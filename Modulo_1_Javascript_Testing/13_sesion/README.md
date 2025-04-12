# Sesión 13: Introducción a JavaScript y Testing

## Fecha: 09/04/2025

## Objetivos de la Sesión

-  Comprender e identificar los distintos tipos de pruebas que se aplican en el desarrollo de software, según su nivel y próposito.

## Temas Cubiertos

1. **Fundamentos de HTML**
   - JSON y almacenamiento local
   - Ejemplos de buenas prácticas y depuración 
   - Fundamentos del Testing
   - Estudiode pruebas unitarias de integración y de sistema.
   - Comparación entre tipos de pruebas.
   - Análisis de ejemplos reales. 

## Ejercicios Realizados

### Ejercicio 13: Mini Framework.

[Ver el Plan de Pruebas](https://github.com/LizzyMr/Academia-Mega/blob/master/Modulo_1_Javascript_Testing/12_sesion/Plan%20de%20Pruebas.pdf)

```html
<!-- index.html -->
<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Mini Framework de Pruebas</title>
</head>
<body>
    <h1>Mini Framework de Pruebas</h1>
    <script src="script.js"></script>
</body>
</html>
```

```js
//script.js
function expect(actual){
    return{
        toBo(expected){
            if(actual === expected){
                console.log(`Pasó: ${actual} === ${expected}`);
            }else{
                console.log(`Falló: se esperaba ${expected}, pero se obtuvo ${actual}`);
            }
        },
        toEqual(expected){
            const passed = JSON.stringify(actual) === JSON.stringify(expected);
            if(passed){
                console.log(`Pasó: Objetos iguales.`);
            }else{
                console.log(`Falló: Objetos diferentes.`);
            }
        }
    }
}

function sumar(a, b){
    return a + b;
}

function validarUsuario(usuario){
    return usuario.nombre && /^[^\s@]+@[^\s@]+\.[^\s@]+$/.test(usuario.correo);
}

const usuarioValido = {nombre: "Ana", correo: "ana@gmail.com"}
const usuarioInvalido = {nombre: "Ulises", correo: "ulises@mail"}

expect(sumar(1,3)).toBo(5);
expect(sumar(10,0)).toBo(10);

expect(validarUsuario(usuarioValido)).toBo(true);
expect(validarUsuario(usuarioInvalido)).toBo(true);

expect(usuarioValido).toEqual(usuarioInvalido);
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