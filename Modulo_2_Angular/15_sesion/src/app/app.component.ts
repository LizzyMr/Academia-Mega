import { Component } from '@angular/core';
import { RouterLink, RouterOutlet } from '@angular/router';
import { Saludo } from './Components/Saludo/saludo.components';
import { CardComponent } from './Components/card/card.component';
import { TarjetaComponent } from './Components/tarjeta/tarjeta.component';
import { CommonModule } from '@angular/common';
import { TodoComponent } from './Components/todo/todo.component';
import { ProductManagerComponent } from './Components/product-manager/product-manager.component';
import { EdadPipe } from './Pipes/edad.pipe';

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
    RouterLink,
    EdadPipe
  ],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  nombre = "Lizeth Martínez Romero"
  fechaNacimiento = "01/09/2000"
  salario = 5000
}
