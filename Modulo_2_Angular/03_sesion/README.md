# Sesión 03: Introducción a Angular

## Fecha: 23/04/2025

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

### Ejercicio 03: Crear e integrar un Componente.

```html
<!-- app.component.html -->
<h1>Este es el componente principal</h1>

<h2>Estos son los componentes secundarios</h2>
<div class="container">
    <app-tarjeta></app-tarjeta>
</div>
```

```ts
// app.component.ts
import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { Saludo } from './Components/Saludo/saludo.components';
import { CardComponent } from './Components/card/card.component';
import { TarjetaComponent } from './Components/tarjeta/tarjeta.component';

@Component({
  selector: 'app-root',
  imports: [RouterOutlet, Saludo, CardComponent, TarjetaComponent],
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
.container{
    display: grid;
    grid-template-columns: 25% 25% 25% 25%;
    gap: 30px;
}
```

```html
<!-- tarjeta.component.html -->
<div class="card">
    <h2>{{mensaje}}</h2>
    <img [src]="imagen" alt="Foto de perfil">
    <input type="text" [(ngModel)]="nombre" placeholder="Escribe tu nombre">
    <input type="text" [(ngModel)]="imagen" placeholder="URL de tu imagen">

    <button (click)="cambiarSaludo()">Actualizar Datos</button>
</div>
```

```ts
// tarjeta.component.ts
import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-tarjeta',
  imports: [FormsModule],
  templateUrl: './tarjeta.component.html',
  styleUrl: './tarjeta.component.css'
})
export class TarjetaComponent {
  nombre: string = "";
  imagen: string = "https://picsum.photos/640/640?r1";
  mensaje: string = "¡Bienvenido!";

  cambiarSaludo(){
    this.mensaje = `¡Hola ${this.nombre || "visitante"}!`;
  }
}
```

```css
/* tarjeta.component.css */
.card{
    border: 1px solid #ccc; 
    padding: 16px;
    max-width: 300px;
    border-radius: 8px;
    text-align: center;
}
img{
    border-radius: 50%;
    margin-bottom: 12px;
    width: 70%;
}
input{
    display: block;
    margin: 8px auto;
    width: 90%;
    padding: 4px;
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