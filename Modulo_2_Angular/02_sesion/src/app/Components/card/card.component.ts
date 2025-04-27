import { Component } from '@angular/core';

@Component({
  selector: 'app-card',
  imports: [],
  templateUrl: './card.component.html',
  styleUrl: './card.component.css'
})
export class CardComponent {
  title = "Esto es una card";
  contenido = "Estas son las card que vamos a estar trabajando";
  botonTxt = "conocer más"

  img = "https://picsum.photos/640/640?r" + Math.random();
}
