# Sesión 09: Angular

## Fecha: 02/04/2025

## Objetivos de la Sesión

- Aprender a manejar la navegación entre páginas en Angular usando el módulo de rutas (AppRouters).

## Temas Cubiertos

1. **Fundamentos de Angular**
   - Directivas básicas (I y II).
   - Manejo de eventos en Angular.
   - Comunicación entre componentes.
   - Uso de servicios en Angular.

## Ejercicios Realizados

### Ejercicio 09: Uso de dos Componentes Hijo y un Componente Padre.

```html
<!-- productos-info.component.html -->
<h1>Lista de Productos</h1>

<p>{{itemSeleccionado?.nombre}}</p>

<div class="container">

    <!-- Columna de Productos -->
    <div class="containerProductos">
        <app-productos
            *ngFor="let item of items"
            [info]="item"
            (seleccionado)="seleccionarItem($event)"
            class="card"
        ></app-productos>
    </div>


    <!-- Columna de Detalle -->
    <div style="width: 50%;">
        <app-detalles [item]="itemSeleccionado"></app-detalles>
    </div>
</div>
 ```

```ts
// productos-info.component.ts
import { Component } from '@angular/core';
import { CardComponent } from '../../Components/card/card.component';
import { ProductosComponent } from '../../Components/productos/productos.component';
import { CommonModule } from '@angular/common';
import { DetallesComponent } from '../../Components/detalles/detalles.component';

@Component({
  selector: 'app-productos-info',
  imports: [CardComponent, ProductosComponent, CommonModule, DetallesComponent],
  templateUrl: './productos-info.component.html',
  styleUrl: './productos-info.component.css'
})
export class ProductosInfoComponent {

  //API
  items = [
    {id: 1, nombre: 'Producto A', descripcion: 'Descripcion del producto A', precio:100},
    {id: 2, nombre: 'Producto B', descripcion: 'Descripcion del producto B', precio:200},
    {id: 3, nombre: 'Producto C', descripcion: 'Descripcion del producto C', precio:300},
    {id: 4, nombre: 'Producto D', descripcion: 'Descripcion del producto D', precio:400},
    {id: 5, nombre: 'Producto E', descripcion: 'Descripcion del producto E', precio:500},
  ]

  itemSeleccionado:any = null;

  seleccionarItem(item:any){
    this.itemSeleccionado = item;
  }
}
```

```css
/* productos-info.components.css */
.container{
    display: flex;
    gap: 2rem;
}
.containerProductos{
    width: 50%;
}

@media (max-width: 600px){
    .container{
        display: block;
        width: 100%;
        background-color: #adadad;
        color: black;
    }
    .containerProductos{
        width: 100%;
    }
    .card{
        display: block;
        width: 100%;
    }
}
```

```html
<!-- productos.component.css -->
<div 
    style="
    border: 1px solid #ccc;
    padding: 1rem;
    margin-bottom: 1rem;
    border-radius: 10px;
    cursor: pointer;
    "
    (click)="seleccionar()"
>
    <h3>{{info.nombre}}</h3>
    <p>Descripción: {{info.descripcion}}</p>
    <p>Precio: {{info.precio}}</p>
</div>
```

```ts
// productos.component.ts
import { Component, EventEmitter, Input, Output } from '@angular/core';

@Component({
  selector: 'app-productos',
  imports: [],
  templateUrl: './productos.component.html',
  styleUrl: './productos.component.css'
})
export class ProductosComponent {
  @Input() info:any;
  @Output() seleccionado = new EventEmitter();

  seleccionar(){
    this.seleccionado.emit(this.info);
  }
}
```

```html
<!-- detalles.component.html -->
<div *ngIf="item; else seleccionaAlgo">
    <h2>Detalles del Producto</h2>
    <p><strong>Nombre:</strong>{{item.nombre}}</p>
    <p><strong>Descripción:</strong>{{item.descripcion}}</p>
    <p><strong>Precio:</strong>{{item.precio}}</p>
</div>

<ng-template #seleccionaAlgo>
    <p>Selecciona un producto para ver los detalles</p>
</ng-template>
```

```ts
// detalles.component.ts
import { CommonModule } from '@angular/common';
import { Component, Input } from '@angular/core';

@Component({
  selector: 'app-detalles',
  imports: [CommonModule],
  templateUrl: './detalles.component.html',
  styleUrl: './detalles.component.css'
})
export class DetallesComponent {
  @Input() item: any;
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