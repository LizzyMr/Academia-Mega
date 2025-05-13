# Sesión 10: Angular

## Fecha: 05/05/2025

## Objetivos de la Sesión

- Aprender a usar servicios y @Injectable().

## Temas Cubiertos

1. **Fundamentos de Angular**
   - Introducción  a routing en Angular.
   - Formularios en Angular.
   - Introducción a consumo de APIs con HTTP Client.
   - Manejo de estados con Services y Observables.
   - Implementación de un CRUD Completo.

## Ejercicios Realizados

### Ejercicio 10: Uso de @Injectable()

```ts
// data.service.ts
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class DataService {

  private message = "Hola desde el Servicio";

  getMessage(){
    return this.message;
  }

  setMessage(newMessage: string){
    this.message = newMessage;
  }

}
```
```html
<!-- service-page.component.html -->
<h1>Clase de Servicios</h1>
<h2>Componente Padre</h2>

<input type="text" [(ngModel)]="newMessage" placeholder="Escrible el mensaje">
<button (click)="updateMessage()">Enviar al Hijo</button>
<app-hijo-service></app-hijo-service>
 ```

```ts
// service-page.component.ts
import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { DataService } from '../../Service/data.service';
import { HijoServiceComponent } from '../../Components/hijo-service/hijo-service.component';

@Component({
  selector: 'app-service-page',
  imports: [FormsModule, HijoServiceComponent],
  templateUrl: './service-page.component.html',
  styleUrl: './service-page.component.css'
})
export class ServicePageComponent {
  newMessage = "";

  constructor(private dataService: DataService){}

  updateMessage(){
    this.dataService.setMessage(this.newMessage);
  }
}
```

```html
<!-- hijo-service.component.css -->
<p>Hola soy el Componente Hijo</p>

<p>Mensaje recibido: {{message}}</p>
```

```ts
// hijo-service.component.ts
import { Component } from '@angular/core';
import { DataService } from '../../Service/data.service';

@Component({
  selector: 'app-hijo-service',
  imports: [],
  templateUrl: './hijo-service.component.html',
  styleUrl: './hijo-service.component.css'
})
export class HijoServiceComponent {
  message = "";

  constructor(private dataService: DataService){
  }

  ngDoCheck(){
    this.message = this.dataService.getMessage();
  }
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