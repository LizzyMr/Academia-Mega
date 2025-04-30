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