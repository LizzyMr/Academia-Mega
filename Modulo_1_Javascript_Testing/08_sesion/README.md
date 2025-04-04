# Sesión 8: Introducción a JavaScript y Testing

## Fecha: 02/04/2025

## Objetivos de la Sesión

- Introducción y Fundamentos de HTML
- Práctica utilizando las etiquetas más comunes de HTML para agregar Estilos a nuestra página web. 
- Uso de funciones y localStorage

## Temas Cubiertos

1. **Fundamentos de HTML**
   - JSON y almacenamiento local
   - Ejemplos de buenas prácticas y depuración 
   - Fundamentos del Testing

## Ejercicios Realizados

### Ejercicio 8: Uso de API´s.

```html
<!-- Actividad -->
<!DOCTYPE html>
<html lang="es">
    <head>
        <meta charset="UTF-8" />
        <meta name="viewport" content="width=device-width, initial-scale=1.0">
        <title>Clase 8 - PokeApi</title>
        <style>
            body{
                background-color: rgba(155, 176, 196, 0.527);
                padding: 20px;
                text-align: center;
                font-family: Arial, Helvetica, sans-serif;
            }
            #pokemon-container{
                display: grid;
                grid-template-columns: 200px 200px 200px 200px 200px 200px;
                gap: 15px;
                justify-content: center;
            }
            .card{
                background-color: white;
                padding: 15px;
                border-radius: 10px;
                box-shadow: 0 4px 6px rgba(0, 0, 0, 0.1);
            }
            .card img{
                max-width: 100px;
            }
            .card h2{
                font-size: 18px;
                margin-top: 10px;
                text-transform: capitalize;
            }
        </style>
    </head>
    <body>
        <img src="https://fontmeme.com/permalink/250404/ff33f692acfa0f9664f53c2a8011fb9d.png" alt="fuente-pokemon" border="0"></a>
        <div id="pokemon-container"></div>

        <script>
            async function obtenerPokemones(){
                const container = document.getElementById("pokemon-container");
                for(let i=1; i<=60; i++){
                    try{
                        const respuesta = await fetch(`https://pokeapi.co/api/v2/pokemon/${i}`)
                        //const respuesta = await fetch(`https://rickandmortyapi.com/api/character/${i}`)
                        console.log(respuesta);
                        const data = await respuesta.json();
                        console.log(data);

                        const card = document.createElement("div");
                        card.className = "card";
                        card.innerHTML = `
                        <img src="${data.sprites.front_default}" alt="${data.name}">
                        <h2>${data.name}</h2>
                        `;
                        // card.innerHTML = `
                        // <img src="${data.image}" alt="${data.name}">
                        // <h2>${data.name}</h2>
                        // `;
                        container.appendChild(card)
                    }catch(error){
                        console.log("Error al obtener el Pokemon:", error);
                    }
                }
            }
            obtenerPokemones();
        </script>
    </body>
</html>
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

Esta sesión me ha ayudado a recordar conocimientos básicos sobre HTML, CSS y JS, y lo funcional que es dentro de la programación.

---

*Entregable correspondiente a la Semana 3 del Módulo 1: JavaScript Testing*