# Sesión 7: Introducción a JavaScript y Testing

## Fecha: 01/04/2025

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

### Ejercicio 7: Obtener Usuario.

```html
<!-- Actividad -->
<!DOCTYPE html>
<html lang="es">
    <head>
        <meta charset="UTF-8" />
        <meta name="viewport" content="width=device-width, initial-scale=1.0">
        <title>Actividad 7</title>
    </head>
    <body>
        <script src="clase7.js"></script>
    </body>
</html>
```

```js

//Ejercicio 6: Obtener Usuario. 
// Actividad
function obtenerUsuario(id){
    try{
        if(typeof id !== "number") throw new Error("El ID debe ser un número");

        const usuarios = { 1: "Ana", 2: "Carlos", 3: "María" };
        if(!usuarios[id]) throw new Error("Usuario no encontrado");

        return `Usuario encontrado: ${usuarios[id]}`;
    }catch(error){
        console.error("Error:", error.message);
        return null;
    }
}

console.log(obtenerUsuario(2));
console.log(obtenerUsuario(3));
console.log(obtenerUsuario(1));
console.log(obtenerUsuario(8));
console.log(obtenerUsuario("a"));
console.log(obtenerUsuario("."));
console.log(obtenerUsuario(-3));
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

Esta sesión me ha ayudado a recordar conocimientos básicos sobre HTML y JS, y lo funcional que es dentro de la programación.

---

*Entregable correspondiente a la Semana 3 del Módulo 1: JavaScript Testing*