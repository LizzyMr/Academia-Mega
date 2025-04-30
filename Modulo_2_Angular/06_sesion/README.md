# Sesión 06: Angular

## Fecha: 28/04/2025

## Objetivos de la Sesión

- Aprender a manejar la navegación entre páginas en Angular usando el módulo de rutas (AppRouters).

## Temas Cubiertos

1. **Fundamentos de Angular**
   - Directivas básicas (I y II).
   - Manejo de eventos en Angular.
   - Comunicación entre componentes.
   - Uso de servicios en Angular.

## Ejercicios Realizados

### Ejercicio 06: Introducción a Routing en Angular.

```html
<!-- app.component.html -->
<h1>Rutas</h1>
<nav>
   <ul>
      <a routerLink="/">Home</a>
      <a routerLink="/card">Card</a>
      <a routerLink="/todo">Todo</a>
      <a routerLink="/gestor">Gestor</a>
      <a routerLink="/tarjeta">Tarjeta</a>
   </ul>
</nav>
<router-outlet></router-outlet>
```

```ts
// app.component.ts
import { Component } from '@angular/core';
import { RouterLink, RouterOutlet } from '@angular/router';
import { Saludo } from './Components/Saludo/saludo.components';
import { CardComponent } from './Components/card/card.component';
import { TarjetaComponent } from './Components/tarjeta/tarjeta.component';
import { CommonModule } from '@angular/common';
import { TodoComponent } from './Components/todo/todo.component';
import { ProductManagerComponent } from './Components/product-manager/product-manager.component';

@Component({
  selector: 'app-root',
  imports: [
    RouterOutlet, 
    Saludo, 
    CardComponent, 
    TarjetaComponent, 
    CommonModule,
    TodoComponent,
    ProductManagerComponent,
    RouterLink
  ],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {}
```

```css
/* app.component.css */
.container{
    display: grid;
    grid-template-columns: 25% 25% 25% 25%;
    gap: 30px;
}

a{
    margin: 12px;
    padding: 12px 24px;
}
```

```ts
// app.routes.ts
import { Routes } from '@angular/router';
import { CardComponent } from './Components/card/card.component';
import { TodoComponent } from './Components/todo/todo.component';
import { ProductManagerComponent } from './Components/product-manager/product-manager.component';
import { HomeComponent } from './Page/home/home.component';
import { ErrorComponent } from './Page/error/error.component';
import { TarjetaComponent } from './Components/tarjeta/tarjeta.component';

export const routes: Routes = [
    {
        path:'',
        component: HomeComponent
    },
    {
        path:'card',
        component: CardComponent
    },
    {
        path:'todo',
        component: TodoComponent
    },
    {
        path:'gestor',
        component: ProductManagerComponent
    },
    {
        path:'tarjeta',
        component: TarjetaComponent
    },
    {
        path:'**',
        component: ErrorComponent
    },
];
```

```html
<!-- home.component.html -->
<h1>Home Page</h1>
<p>Bienvenidos a mi página</p>
```

```ts
// home.component.ts
import { Component } from '@angular/core';

@Component({
  selector: 'app-home',
  imports: [],
  templateUrl: './home.component.html',
  styleUrl: './home.component.css'
})
export class HomeComponent {

}
```

```html
<!-- error.component.css -->
<h1>Error 404</h1>
<h2>Página no encontrada</h2>
```

```ts
// error.component.css
import { Component } from '@angular/core';

@Component({
  selector: 'app-error',
  imports: [],
  templateUrl: './error.component.html',
  styleUrl: './error.component.css'
})
export class ErrorComponent {

}
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