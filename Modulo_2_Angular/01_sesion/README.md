# Sesión 01: Introducción a Angular

## Fecha: 21/04/2025

## Objetivos de la Sesión

- Introducción a Angular.

## Temas Cubiertos

1. **Fundamentos de Angular**
   - ¿Qué es Angular?
   - Estructura de un proyecto Angular.
   - Creación de componentes.
   - Templates y Data Binding (I II).

## Ejercicios Realizados

### Ejercicio 01: 

```html
<!-- app.component.html -->
<nav>
  <ul>
    <li>
      Bienvenidos
    </li>
    <li>
      Nosotros
    </li>
    <li>
      Productos
    </li>
  </ul>
</nav>
<main>
  <h1>{{titulo}} {{name}}</h1>
  <h2> Soy {{dato}} y tengo {{edad}} años</h2>
  <form action="">
    <input type="text">
    <input type="text">
    <input type="text">
    <button type="text">Envíar</button>
  </form>
</main>

```

```ts
// app.component.ts
import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';

@Component({
  selector: 'app-root',
  imports: [RouterOutlet],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  titulo = 'Bienvenidos a mi página web';
  name = 'Lizeth Martínez';
  dato = 'Ing. Informática';
  edad = 25;
}

```

```css
/* app.component.css */
li{
    color: red;
    font-family: Arial, Helvetica, sans-serif;
}
form{
    width: 400px;
    text-align: center;
}
input{
    display: block;
    padding: 6px;
    margin: 6px;
}
button{
    width: 50%;
}
```

## Desafíos Encontrados

- **Sin impedimentos:** Por el momento no tuve ningún inconveniente al realizar esta actividad.  

## Recursos Adicionales

- Curso de Angular 19 Moderno: Domina Angular
- Curso de Angular Avanzado: MEAN, JWT, Módulos, Animaciones
- Angular desde cero a experto: Crear una aplicación real
- Legacy-Angular Avanzado: Lleva tus bases al siguiente nivel
- Master en Frameworks JavaScript: Aprende Angular, React, Vue
- Angular 4: Conviértete en Desarrollador Web Full Stack
- Máster en programación fullstack JavaScript Angular Node
- Angular desde cero (Incluye MEAN Stack)

## Próximos Pasos

- Continuar los avances en cursos de prerrequisitos. 
- Practicar los ejercicios realizados en la sesión.

## Reflexiones Personales

Esta sesión me ha ayudado a recordar conocimientos básicos sobre Angular, así como de JavaScript y lo funcional que es dentro de la programación.

---

*Entregable correspondiente a la Semana 6 del Módulo 2: Angular*