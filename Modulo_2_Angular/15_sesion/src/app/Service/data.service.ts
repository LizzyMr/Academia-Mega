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
