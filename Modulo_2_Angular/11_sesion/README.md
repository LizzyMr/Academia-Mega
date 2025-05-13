# Sesión 11: Angular

## Fecha: 06/05/2025

## Objetivos de la Sesión

- Aprender a usar formularios en Angular.

## Temas Cubiertos

1. **Fundamentos de Angular**
   - Introducción  a routing en Angular.
   - Formularios en Angular.
   - Introducción a consumo de APIs con HTTP Client.
   - Manejo de estados con Services y Observables.
   - Implementación de un CRUD Completo.

## Ejercicios Realizados

### Ejercicio 11: Uso de Formularios.

```ts
// app.routes.ts
import { Routes } from '@angular/router';
import { CardComponent } from './Components/card/card.component';
import { TodoComponent } from './Components/todo/todo.component';
import { ProductManagerComponent } from './Components/product-manager/product-manager.component';
import { HomeComponent } from './Page/home/home.component';
import { ErrorComponent } from './Page/error/error.component';
import { TarjetaComponent } from './Components/tarjeta/tarjeta.component';
import { ProductosInfoComponent } from './Page/productos-info/productos-info.component';
import { ServicePageComponent } from './Page/service-page/service-page.component';
import { FormularioComponent } from './Page/formulario/formulario.component';

export const routes: Routes = [
    {
        path:'',
        component: FormularioComponent
    },
    {
        path:'servicios',
        component: ServicePageComponent
    },
    {
        path:'componentes',
        component: ProductosInfoComponent
    },
    {
        path:'home',
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
<!-- formulario.component.html -->
<div class="container">
    <h1>Registro de Usuario</h1>
    <form #formulario="ngForm" (ngSubmit)="onSubmit()">

        <!-- Nombre -->
        <div class="form-control">
            <label for="nombre">Nombre</label>
            <input 
                type="text" 
                id="nombre" 
                name="nombre" 
                [(ngModel)]="usuario.nombre"
                required
                minlength="3"
                #nombre="ngModel"
            >
            <div class="error" *ngIf="nombre.invalid && nombre.touched">
                El nombre es obligatorio y debe tener al menos 3 caracteres
            </div>
        </div>

        <!-- Email -->
        <div class="form-control">
            <label for="email">Email:</label>
            <input 
                type="email" 
                id="email" 
                name="email" 
                [(ngModel)]="usuario.email"
                required
                minlength="3"
                #email="ngModel"
            >
            <div class="error" *ngIf="email.invalid && email.touched">
                Ingresa un Correo válido
            </div>
        </div>

        <!-- Edad -->
        <div class="form-control">
            <label for="edad">Edad:</label>
            <input 
                type="number" 
                id="edad" 
                name="edad" 
                [(ngModel)]="usuario.edad"
                required
                min="18"
                #edad="ngModel"
            >
            <div class="error" *ngIf="edad.invalid && edad.touched">
                Debes tener al menos 18 años
            </div>
        </div>

        <!-- Boton -->
        <button
            [disabled]="formulario.invalid"
            type="submit"
        >
            Enviar
        </button>
    </form>
    <h3>Datos Actuales</h3>
    <pre>
        {{usuario | json}}
    </pre>
</div>
 ```

```ts
// formulario.component.ts
import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-formulario',
  imports: [FormsModule, CommonModule],
  templateUrl: './formulario.component.html',
  styleUrl: './formulario.component.css'
})
export class FormularioComponent {
  usuario = {
    nombre: '',
    email: '',
    edad: null
  }

  onSubmit(){
    console.log("Datos del formulario:", this.usuario);
    alert("Formulario enviado correctamente!");
  }
}
```

```css
/* formulario.component.ts */
.container{
    max-width: 400px;
    margin: 40px auto;
    font-family: Arial, Helvetica, sans-serif;
    padding: 24px;
    border-radius: 8px;
    box-shadow: 2px 5px 17px rgba(0, 0, 0, 0.5);
}
.form-control{
    margin-bottom: 15px;
}
label{
    display: block;
    margin-bottom: 5px;
}
input{
    padding: 8px;
    width: 100%;
    box-sizing: border-box;
}
button{
    padding: 10px;
    width: 100%;
    background-color: #007bff;
    color: white;
    border: none;
    font-weight: bold;
    cursor: pointer;
}
button:disabled{
    background-color: #ccc;
    cursor: not-allowed;
}
.error{
    color: red;
    font-size: 13px;
}
```

## Desafíos Encontrados

- **Sin impedimentos:** Por el momento no tuve ningún inconveniente al realizar esta actividad.  

## Recursos Adicionales

- Curso de Angular 19 - Desde cero hasta profesional
- Angular - Formularios: curso intensivo (Angular 8+)
- Angular PRO desde cero: El curso definitivo (Angular 8+)
- RxJS nivel PRO
- Curso de Angular Avanzado: MEAN, JWT, Módulos, Animaciones

## Próximos Pasos

- Continuar los avances en cursos de Udemy. 
- Practicar los ejercicios realizados en la sesión.

## Reflexiones Personales

Esta sesión me ha ayudado a recordar conocimientos básicos sobre Angular, así como de JavaScript y lo funcional que es dentro de la programación.

---

*Entregable correspondiente a la Semana 8 del Módulo 2: Angular*