# Sesión 12: Angular

## Fecha: 07/05/2025

## Objetivos de la Sesión

- Aprender a consumir una API externa en Angular utilizando el módulo HttpClientModule.

## Temas Cubiertos

1. **Fundamentos de Angular**
   - Introducción  a routing en Angular.
   - Formularios en Angular.
   - Introducción a consumo de APIs con HTTP Client.
   - Manejo de estados con Services y Observables.
   - Implementación de un CRUD Completo.

## Ejercicios Realizados

### Ejercicio 12: Uso de HttpClientModule.

```ts
// api-service.services.ts
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ApiDataService {
  private apiUrl = 'http://fakestoreapi.com/products';

  constructor(private http:HttpClient) { }

  getProduct(): Observable<any>{
    return this.http.get(this.apiUrl);
  }
}
```
```html
<!-- product-list.component.html -->
<h1>Clase HTTP-Client</h1>
<h2>Lista de Productos</h2>

<div class="products-container">
  <div class="product-card" *ngFor="let product of products">
    <img [src]="product.image" alt="{{ product.title }}">
    <h3>{{ product.title }}</h3>
    <p>{{ product.description }}</p>
    <strong>${{ product.price }}</strong>
  </div>
</div>
 ```

```ts
// product-list.component.ts
import { Component } from '@angular/core';
import { ApiDataService } from '../../Service/api-service.service';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-product-list',
  imports: [CommonModule],
  templateUrl: './product-list.component.html',
  styleUrl: './product-list.component.css'
})
export class ProductListComponent {
  products: any[] = [];
  constructor(private productService: ApiDataService){

  }

  ngOnInit(){
    this.productService.getProduct().subscribe(data => {
      this.products = data;
    })
  }
}
```

```css
/* product-list.component.ts */
:host {
  display: block;
  padding: 2rem;
  background: linear-gradient(to right, #f0f4f8, #d9e2ec);
  font-family: 'Poppins', 'Segoe UI', sans-serif;
  min-height: 100vh;
  color: #333;
}

h1, h2 {
  text-align: center;
  margin-bottom: 1rem;
  font-weight: 600;
}

h1 {
  font-size: 2.5rem;
  color: #2c3e50;
}

h2 {
  font-size: 1.5rem;
  color: #5a5a5a;
  margin-bottom: 2rem;
}

.products-container {
  display: flex;
  flex-wrap: wrap;
  justify-content: center;
  gap: 2rem;
}

.product-card {
  background: white;
  border-radius: 16px;
  padding: 1.5rem;
  width: 300px;
  box-shadow: 0 10px 25px rgba(0, 0, 0, 0.1);
  transition: transform 0.3s ease, box-shadow 0.3s ease;
  display: flex;
  flex-direction: column;
  align-items: center;
}

.product-card:hover {
  transform: translateY(-8px);
  box-shadow: 0 20px 40px rgba(0, 0, 0, 0.15);
}

.product-card img {
  max-width: 100%;
  height: 200px;
  object-fit: contain;
  border-radius: 10px;
  margin-bottom: 1rem;
  background: #f8f8f8;
  padding: 10px;
}

.product-card h3 {
  font-size: 1.2rem;
  font-weight: 600;
  color: #1e272e;
  text-align: center;
  margin-bottom: 0.5rem;
}

.product-card p {
  font-size: 0.95rem;
  color: #555;
  line-height: 1.4;
  text-align: justify;
  margin-bottom: 1rem;
  max-height: 80px;
  overflow: hidden;
  text-overflow: ellipsis;
}

.product-card strong {
  font-size: 1.2rem;
  color: #0abf53;
  font-weight: bold;
  margin-top: auto;
  background: #e8f8f2;
  padding: 0.4rem 0.8rem;
  border-radius: 8px;
}

/* Responsive */
@media (max-width: 768px) {
  .product-card {
    width: 90%;
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