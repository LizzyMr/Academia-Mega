# Sesión 04: Introducción a Angular

## Fecha: 24/04/2025

## Objetivos de la Sesión

- Introducción a Angular.
- Crear un nuevo componente.
- Integrar correctamente este componente.

## Temas Cubiertos

1. **Fundamentos de Angular**
   - ¿Qué es Angular?
   - Estructura de un proyecto Angular.
   - Creación de componentes.
   - Uso de ngIf y ngFor.
   - Templates y Data Binding (I II).

## Ejercicios Realizados

### Ejercicio 04: Uso de ngIf y ngFor.

```html
<!-- app.component.html -->
<h1>Directivas Estructurales</h1>
<app-todo></app-todo>
```

```ts
// app.component.ts
import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { Saludo } from './Components/Saludo/saludo.components';
import { CardComponent } from './Components/card/card.component';
import { TarjetaComponent } from './Components/tarjeta/tarjeta.component';
import { CommonModule } from '@angular/common';
import { TodoComponent } from './Components/todo/todo.component';

@Component({
  selector: 'app-root',
  imports: [
    RouterOutlet, 
    Saludo, 
    CardComponent, 
    TarjetaComponent, 
    CommonModule,
    TodoComponent
  ],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {

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

```html
<!-- todo.component.html -->
<div class="todo-container">
    <h2>Lista de Tareas</h2>

    <div style="display: flex; margin-bottom: 1rem;">
        <input type="text" [(ngModel)]="nuevaTarea" placeholder="Nueva tarea...">
        <button (click)="agregarTareas()">Agregar</button>
    </div>
    <button (click)="limpiarTareas()">Limpiar</button>
    
    <p *ngIf="tareas.length === 0">No hay tareas pendientes</p>
    <ul>
        <li *ngFor="let tarea of tareas; let i = index">
            <span [style.textDecoration]="tarea.completada? 'line-through': 'none'">
                {{tarea.texto}}
            </span>
            <button 
            (click)="toggleCompletar(i)"
            >{{tarea.completada? "Desmarcar":"Completar"}}</button>
        </li>
    </ul>
</div>
```

```ts
// todo.component.ts
import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-todo',
  imports: [FormsModule, CommonModule],
  templateUrl: './todo.component.html',
  styleUrl: './todo.component.css'
})
export class TodoComponent {

  nuevaTarea = "";

  tareas = [
    { texto : "Aprender Angular", completada: false},
    { texto : "Hacer Ejercicio", completada: true}
  ]

  agregarTareas(){
    if(this.nuevaTarea.trim()){
      this.tareas
      .push({texto: this.nuevaTarea, completada:false});
      this.nuevaTarea = "";
    }
  }

  limpiarTareas(){
    this.tareas = [];
  }

  toggleCompletar(index: number){
    this.tareas[index].completada = !this.tareas[index].completada;
  }
}
```

```css
/* todo.component.css */
.todo-container{
    max-width: 500px;
    margin: 2rem auto;
    padding: 1.5rem;
    border: 1px solid #ccc;
    border-radius: 10px;
    box-shadow: 2px 2px 8px rgba(0, 0, 0, 0.1);
    background-color: #f9f9f9;
}

.todo-container h2{
    text-align: center;
    margin-bottom: 1rem;
    color: #333;
}

input{
    width: calc(100% - 110px);
    padding: 0.5rem;
    margin-right: 10px;
    border: 1px solid #ccc;
    border-radius: 5px;
}
button{
    padding: 0.5rem 0.75rem;
    margin-top: 0.5rem;
    border: none;
    border-radius: 5px;
    background-color: #007acc;
    color: white;
    cursor: pointer;
    transition: background-color 0.2s;
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