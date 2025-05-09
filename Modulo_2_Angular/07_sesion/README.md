# Sesión 07: Angular

## Fecha: 29/04/2025

## Objetivos de la Sesión

- Aprender a manejar la navegación entre páginas en Angular usando el módulo de rutas (AppRouters).

## Temas Cubiertos

1. **Fundamentos de Angular**
   - Directivas básicas (I y II).
   - Manejo de eventos en Angular.
   - Comunicación entre componentes.
   - Uso de servicios en Angular.

## Ejercicios Realizados

### Ejercicio 07: Uso de @Input.

```html
<!-- home.component.html -->
<h1>Componente Padre</h1>
<p>Aquí vamos a poner un componente hijo</p>

<div style="display: flex; flex-wrap: wrap; gap: 1rem"> 
    <app-hijo
    *ngFor="let usuario of usuarios"
    [info]="usuario"
    ></app-hijo>
</div>
 
```

```ts
// home.component.ts
import { Component } from '@angular/core';
import { HijoComponent } from '../../Components/hijo/hijo.component';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-home',
  imports: [HijoComponent, CommonModule],
  templateUrl: './home.component.html',
  styleUrl: './home.component.css'
})
export class HomeComponent {
  //Simulacion de API
  usuarios = [
    {nombre: "Juan", edad: 25, profesion: "Ingeniero"},
    {nombre: "Ana", edad: 23, profesion: "Diseñadora"},
    {nombre: "Luis", edad: 29, profesion: "Estudiante"},
    {nombre: "Omar", edad: 22, profesion: "Arquitecto"},
  ]
}
```

```html
<!-- error.component.css -->
<div class="card">
    <h3>{{info.nombre}}</h3>
    <p><strong>Edad:</strong>{{info.edad}}</p>
    <p><strong>Profesión:</strong>{{info.profesion}}</p>
</div>
```

```ts
// error.component.css
import { Component, Input } from '@angular/core';

@Component({
  selector: 'app-hijo',
  imports: [],
  templateUrl: './hijo.component.html',
  styleUrl: './hijo.component.css'
})
export class HijoComponent {
  @Input() info = {
    nombre: '',
    edad: 0,
    profesion: ''
  }
}
```

```css
/* app.component.css */
.card{
    border: 1px solid #ccc;
    padding: 1rem;
    border-radius: 10px;
    width: 200px;
    box-shadow: 2px 2px 6px rgba(0,0,0,0.1)
;}
```
## Desafíos Encontrados

- **Sin impedimentos:** Por el momento no tuve ningún inconveniente al realizar esta actividad.  

## Recursos Adicionales

- Angular desde cero a experto: Crear una aplicación real
- Legacy-Angular: desde cero a experto
- Master en JavaScript: Aprender JS, jQuery, Angular, NodeJS
- Desarrollo frontend con Angular (2025)
- Master en Frameworks JavaScript: Aprende Angular, React, Vue
- Angular desde cero (Incluye MEAN Stack)

## Próximos Pasos

- Continuar los avances en cursos de Udemy. 
- Practicar los ejercicios realizados en la sesión.

## Reflexiones Personales

Esta sesión me ha ayudado a recordar conocimientos básicos sobre Angular, así como de JavaScript y lo funcional que es dentro de la programación.

---

*Entregable correspondiente a la Semana 7 del Módulo 2: Angular*