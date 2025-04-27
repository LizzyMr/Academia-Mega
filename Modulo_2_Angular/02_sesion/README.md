# Sesión 02: Introducción a Angular

## Fecha: 22/04/2025

## Objetivos de la Sesión

- Introducción a Angular.
- Crear un nuevo componente.
- Integrar correctamente este componente.

## Temas Cubiertos

1. **Fundamentos de Angular**
   - ¿Qué es Angular?
   - Estructura de un proyecto Angular.
   - Creación de componentes.
   - Templates y Data Binding (I II).

## Ejercicios Realizados

### Ejercicio 02: Crear e integrar un Componente.

```html
<!-- app.component.html -->
<h1>Este es el componente principal</h1>

<h2>Estos son los componentes secundarios</h2>
<div class="container">
    <app-card></app-card>
    <app-card></app-card>
    <app-card></app-card>
    <app-card></app-card>
    <app-card></app-card>
    <app-card></app-card>
    <app-card></app-card>
    <app-card></app-card>
    <app-card></app-card>
    <app-card></app-card>
    <app-card></app-card>
    <app-card></app-card>
</div>
```

```ts
// app.component.ts
import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { Saludo } from './Components/Saludo/saludo.components';
import { CardComponent } from './Components/card/card.component';

@Component({
  selector: 'app-root',
  imports: [RouterOutlet, Saludo, CardComponent],
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
/* card.component.css */
.card{
    background-color: white;
    width: 300px;
    border-radius: 10px;
    box-shadow: 0 4px 8px rgba(0,0,0,0.1);
    transition: transform 0.3s ease-in-out;
}
.card:hover{
    transform: translateY(-5px);
}
.card img{
    width: 100%;
    height: 200px;
    object-fit: cover;
}
.card-content{
    padding: 15px;
}
.card-title{
    font-size: 18px;
    font-weight: bold;
    margin-bottom: 10px;
}
.card-description{
    font-size: 14px;
    color: #555;
    margin-bottom: 15px;
}
.btn{
    display: inline-block;
    background-color: #007bff;
    color: white;
    border: none;
    padding: 10px 20px;
    border-radius: 5px;
    text-align: center;
    transition: background-color 0.3s ease;
}
.btn:hover{
    background-color: #0056b3;
}
```

```css
/* app.component.css */
.container{
    display: grid;
    grid-template-columns: 25% 25% 25% 25%;
    gap: 30px;
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