# Sesión 05: Introducción a Angular

## Fecha: 25/04/2025

## Objetivos de la Sesión

- Introducción a Angular.
- Crear un nuevo componente.
- Integrar correctamente este componente.

## Temas Cubiertos

1. **Fundamentos de Angular**
   - ¿Qué es Angular?
   - Estructura de un proyecto Angular.
   - Creación de componentes.
   - Uso de ngIf, ngFor, ngSwitch, ngSwitchCase, ngClass.
   - Templates y Data Binding (I II).

## Ejercicios Realizados

### Ejercicio 05: 

```html
<!-- app.component.html -->
<h1>Directivas Estructurales</h1>
<app-product-manager></app-product-manager>
```

```ts
// app.component.ts
import { Component } from '@angular/core';
import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
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
    ProductManagerComponent
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
<!-- product-manager.component.html -->
<div class="container">
    <h2>Gestor de Productos</h2>
    <div class="categoria-buttons">
        <button 
            (click)="categoriaSeleccionada = 'electronica'"
            [ngClass]="{'activo': categoriaSeleccionada === 'electronica'}">
            Electrónica
        </button>
        <button 
            (click)="categoriaSeleccionada = 'ropa'"
            [ngClass]="{'activo': categoriaSeleccionada === 'ropa'}">
            Ropa
        </button>
        <button 
            (click)="categoriaSeleccionada = 'alimentos'"
            [ngClass]="{'activo': categoriaSeleccionada === 'alimentos'}"> 
            Alimentos
        </button>
    </div>

    <div [ngSwitch] = "categoriaSeleccionada">

        
        <!-- Electrónica -->
        <div *ngSwitchCase="'electronica'">
            <h3>Productos Electrónicos</h3>
            <ng-container *ngIf="productos.electronica.length > 0">
                <div *ngFor="let p of productos.electronica"
                    [ngClass]="{'agotado':!p.disponible}"
                    [ngStyle]="{'color': p.descuento>0?'green':'black'}"
                    class="producto"
                    >
                    {{p.nombre}} - ${{p.precio}}
                    <span *ngIf="p.descuento > 0">(Descuento {{p.descuento}}%)</span>
                    <span *ngIf="!p.descuento">- No disponible</span>
                </div>
            </ng-container>
        </div>

        <!-- Ropa -->
         <div *ngSwitchCase="'ropa'">
            <h3>Productos de Ropa</h3>
            <ng-container *ngIf="productos.ropa.length > 0">
                <div *ngFor="let p of productos.ropa"
                    [ngClass]="{'agotado':!p.disponible}"
                    [ngStyle]="{'color': p.descuento>0?'green':'black'}"
                    class="producto"
                    >
                    {{p.nombre}} - ${{p.precio}}
                    <span *ngIf="p.descuento > 0">(Descuento {{p.descuento}}%)</span>
                    <span *ngIf="!p.descuento">- No disponible</span>
                </div>
            </ng-container>
         </div>

        <!-- Alimentos -->
         <div *ngSwitchCase="'alimentos'">
            <h3>Productos de Alimentos</h3>
            <ng-container *ngIf="productos.alimentos.length > 0">
                <div *ngFor="let p of productos.alimentos"
                    [ngClass]="{'agotado':!p.disponible}"
                    [ngStyle]="{'color': p.descuento>0?'green':'black'}"
                    class="producto"
                    >
                    {{p.nombre}} - ${{p.precio}}
                    <span *ngIf="p.descuento > 0">(Descuento {{p.descuento}}%)</span>
                    <span *ngIf="!p.descuento">- No disponible</span>
                </div>
            </ng-container>
         </div>
    </div>
</div>
```

```ts
// product-manager.component.ts
import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';

@Component({
  selector: 'app-product-manager',
  imports: [CommonModule],
  templateUrl: './product-manager.component.html',
  styleUrl: './product-manager.component.css'
})
export class ProductManagerComponent {
  categoriaSeleccionada = "";

  productos = {
    electronica: [
      {nombre: "Laptop", precio: 12000, disponible: true, descuento: 10},
      {nombre: "Smartphone", precio: 3800, disponible: false, descuento: 0},
      {nombre: "Audífonos", precio: 699, disponible: true, descuento: 10},
      {nombre: "Smartwatch", precio: 1200, disponible: true, descuento: 15},
    ],
    ropa: [
      {nombre: "Camisa", precio: 299, disponible: true, descuento: 0},
      {nombre: "Jeans", precio: 600, disponible: true, descuento: 0},
      {nombre: "Suéter", precio: 350, disponible: true, descuento: 20},
      {nombre: "Sombrero", precio: 199, disponible: true, descuento: 0},
      {nombre: "Zapatos", precio: 1100, disponible: false, descuento: 0},
      {nombre: "Calcetas", precio: 50, disponible: true, descuento: 10},
    ],
    alimentos: [
      {nombre: "Carne Res", precio: 215, disponible: true, descuento: 0},
      {nombre: "Verdura", precio: 80, disponible: true, descuento: 5},
      {nombre: "Pan", precio: 75, disponible: true, descuento: 0},
      {nombre: "Fruta", precio: 75, disponible: true, descuento: 0},
      {nombre: "Leche", precio: 32, disponible: true, descuento: 0},
      {nombre: "Pollo", precio: 210, disponible: true, descuento: 10},
      {nombre: "Jamón", precio: 45, disponible: true, descuento: 0},
    ]
  }
}
```

```css
/* product-manager.component.css */
.container{
    max-width: 600px;
    margin: 2rem auto;
    padding: 1rem;
    background-color: #f9f9f9;
    border-radius: 10px;
    border: 1px solid #ddd;
}

.categoria-buttons {
    display: flex;
    justify-content: space-between;
    margin-bottom: 1rem;
}

.categoria-buttons button {
    flex: 1;
    margin: 0 0.25rem;
    padding: 0.5rem 1rem;
    border: 1px solid #ccc;
    background-color: #e0e0e0;
    cursor: pointer;
    border-radius: 5px;
    transition: background-color 0.3s ease;
}

.categoria-buttons button:hover {
    background-color: #d0d0d0;
}

.categoria-buttons button.activo {
    background-color: #4caf50;
    color: white;
    border-color: #4caf50;
}

h3 {
    margin-top: 1rem;
    color: #333;
    border-bottom: 1px solid #ccc;
    padding-bottom: 0.5rem;
}

.producto{
    padding: 0.75rem;
    margin-bottom: 0.5rem;
    background-color: white;
    border-radius: 5px;
    border: 1px solid #ddd;
}

.agotado{
    opacity: 0.5;
    font-style: italic; 
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
