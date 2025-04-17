# Sesión 14: Introducción a JavaScript y Testing

## Fecha: 10/04/2025

## Objetivos de la Sesión

- Introducción a TDD.
- Aplicar Test Driven Development (TDD).
- Aplicar el enfoque de Desarrollo Guiado por Pruebas (TDD) para mejorar la calidad del código y fomentar buenas prácticas.

## Temas Cubiertos

1. **Fundamentos de TDD**
   - Ejemplos de buenas prácticas.
   - Ciclo Red-Green-Refactor.
   - Beneficios del TDD.

## Ejercicios Realizados

### Ejercicio 14: TDD - Invertir Texto.



```html
<!-- index.html -->
<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>TDD: Invertir Texto</title>
    <style>
        /* *{
            border: 1px solid red;
        } */
        body{
            font-family: Arial, Helvetica, sans-serif;
            padding: 20px;
        }
        .pass{
            color: green;
        }
        .fail{
            color: red;
        }
        pre{
            background-color: #f0f0f0;
            padding: 10px;
            border-radius: 5px;
        }
    </style>
</head>
<body>
    <h1>Testing: Invertir Texto</h1>    
    <div id="result">

    </div>

    <script>
        //Funcion bajo prueba
        function invertirTexto(texto){
            if(typeof texto !== "string") return "";
            return texto.split("").reverse().join("")
        }

        //Sistema de test simple
        function expect(actual){
            return{
                toBe(expected){
                    const passed = actual === expected;
                    const message = passed?
                    `Pasó: ${actual} === ${expected}`
                    :`Falló: ${actual} !== ${expected}`;

                    const result = document.createElement("pre");
                    result.textContent = message;
                    result.className = passed? "pass": "fail";
                    document.getElementById("result").appendChild(result);
                }
            }
        }

        //Prueba
        expect(invertirTexto("hola")).toBe("aloh");
        expect(invertirTexto("TDD")).toBe("DDT");
        expect(invertirTexto("123")).toBe("");
        expect(invertirTexto("abc123")).toBe("321cba");
        expect(invertirTexto("123")).toBe("321");
        expect(invertirTexto("a")).toBe("a");
        expect(invertirTexto("123")).toBe("321");
    </script>
</body>
</html>
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