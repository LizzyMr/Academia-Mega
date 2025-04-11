# Sesión 12: Introducción a JavaScript y Testing

## Fecha: 08/04/2025

## Objetivos de la Sesión

- Introducción y Fundamentos de HTML
- Conocer patrones de diseño básicos
- Uso correcto de errores de validación
- Aprender a diseñar un Plan de Pruebas correctamente

## Temas Cubiertos

1. **Fundamentos de HTML**
   - JSON y almacenamiento local
   - Ejemplos de buenas prácticas y depuración 
   - Fundamentos del Testing
   - Patrones de diseño en JavaScript
   - Validaciones (alfanúmericos, carácteres especiales, campos vacíos, etc.)
   - Diseño de Plan de Pruebas 

## Ejercicios Realizados

### Ejercicio 12: Plan de Pruebas: Calculadora de promedio.

[Descargar el Plan de Pruebas](https://github.com/LizzyMr/Academia-Mega/blob/master/Modulo_1_Javascript_Testing/12_sesion/Plan%20de%20Pruebas.pdf)

```html
<!-- index.html -->
<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Calculadora de Promedio</title>
    <link rel="stylesheet" href="style.css">
</head>
<body>
    <h1>Calculadora de Promedio</h1>

    <form id="formularioNotas">
        <label>Nota 1:</label>
        <input type="number" id="nota1">

        <label>Nota 2:</label>
        <input type="number" id="nota2">

        <label>Nota 3:</label>
        <input type="number" id="nota3">

        <button type="submit">Calcular</button>
    </form>
    
    <div id="resultado"></div>
    <script src="script.js"></script>
</body>
</html>
```
```js - script.js
//script.js
document.getElementById("formularioNotas").addEventListener("submit", function(e){
    e.preventDefault();

    const nota1Str = document.getElementById("nota1").value;
    const nota2Str = document.getElementById("nota2").value;
    const nota3Str = document.getElementById("nota3").value;

    const resultado = document.getElementById("resultado");

    try {
        // Validar si hay campos vacíos
        if (nota1Str === "" || nota2Str === "" || nota3Str === "") {
            throw new Error("Todos los campos tienen que ser llenados.");
        }

        const nota1 = parseFloat(nota1Str);
        const nota2 = parseFloat(nota2Str);
        const nota3 = parseFloat(nota3Str);

        // Validar si son negativos
        if ([nota1, nota2, nota3].some(n => n < 0)) {
            throw new Error("Estas ingresando una nota negativa. Todas las notas deben estar en 0 y 10.");
        }

        const promedio = calcularPromedio(nota1, nota2, nota3);

        resultado.textContent = `El promedio es: ${promedio.toFixed(2)}`;
        resultado.style.color = promedio >= 6 ? "green" : "orange";
    } catch (error) {
        resultado.textContent = error.message;
        resultado.style.color = "red";
    }
});

function calcularPromedio(n1, n2, n3) {
    if ([n1, n2, n3].some(isNaN)) {
        throw new Error("Todas las notas deben ser números válidos.");
    }

    if ([n1, n2, n3].some(n => n > 10)) {
        throw new Error("Todas las notas deben estar entre 0 y 10.");
    }

    return (n1 + n2 + n3) / 3;
}
```

```css
/*style.css*/
body{
    font-family: Arial, Helvetica, sans-serif;
    padding: 20px;
    background-color: #f4f4f4;

}

form{
    background-color: white;
    padding: 15px;
    border-radius: 8px;
    max-width: 300px;
}
label{
    margin-top: 10px;
    display: block;
}
input{
    width: 95%;
    margin-bottom: 10px;
    padding: 5px;
}

button{
    background-color: #27ae60;
    color: white;
    border: none;
    padding: 10px;
    width: 100%;
    border-radius: 5px;
    cursor: pointer;
}

#resultado{
    margin-top: 20px;
    font-weight: bold;
}
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
