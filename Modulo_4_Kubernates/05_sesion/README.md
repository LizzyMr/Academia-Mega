# Sesión 05: Kubernetes

## Fecha: 27/06/2025

## Objetivos de la Sesión

- Utilizando las bases aprendidas durante los cursos de Angular y C#, aprenderemos el uso de los contenedores.

## Temas Cubiertos

1. **Fundamentos de Angular**
   - Introducción  a la virtualización de contenedores.
   - Manejo básico de docker.
   - Alternativas a Docker - Podman y Buildah.
   - Instalación de Kubernetes local con Minikube.
   - Otras distribuciones locales - Kind y K3s.

## Ejercicios Realizados

### Ejercicio 05: Apicación2 - frontend y backend

En el siguiente apartado se adjuntaran los archivos modificados para esta actividad, y tambien encontrarás las capturas de Docker Desktops. 

#### Aplicación 2
docker-compose.yml
```yml
services:
  mongodb:
    image: mongo:latest
    container_name: my-mongo
    ports:
      - '27017:27017'
    volumes:
      - mongo-data:/data/db
    networks:
      - app-net

  backend:
    build:
      context: ./backend
      dockerfile: Dockerfile
    container_name: backend
    env_file:
      - ./backend/src/.env
    depends_on:
      - mongodb
    
  frontend:
    build:
      context: ./frontend
      dockerfile: Dockerfile
    container_name: frontend
    depends_on:
      - backend

volumes:
  mongo-data:

networks:
  app-net:
    driver: bridge 
```

##### backend
index.js
```js
require('dotenv').config();
const express = require('express');
const mongoose = require('mongoose');
const cors = require('cors');

const app = express();
const port = process.env.PORT || 3000;

app.use(cors());
app.use(express.json());

mongoose.connect('mongodb://localhost:27017/myappdb', {
    useNewUrlParser: true,
    useUnifiedTopology: true
})
.then(() => console.log('Conectado a MongoDB'))
.catch(err => console.error('error conectando a MongoDB', err));

const itemsRouter = require('./routes/items');
app.use('/api/items', itemsRouter);

app.listen(port, () => console.log(`API corriendo en http://localhost:${port}`));
```

Dockerfile
```dockerfile
FROM node:22
WORKDIR /usr/src/app
COPY package*.json ./
RUN npm ci
COPY . . 
EXPOSE 3000
CMD ["node", "src/index.js"] 
```

item.js
```js
const {Schema, model} = require('mongoose');

const itemSchema = new Schema({
    name: {type: String, required: true},
    price: {type: Number, required: true}
});

module.exports = model('Item', itemSchema); 
```

items.js
```js
const express = require('express');
const router = express.Router();
const Item = require('../models/item');

// GET all
router.get('/', async (req, res) => {
    const items = await Item.find();
    res.json(items);
});

// POST create
router.post('/', async (req, res) => {
    try {
        const newItem = new Item(req.body);
        const saved = await newItem.save();
        res.status(201).json(saved);
    } catch (e) {
        res.status(400).json({ error: e.message });
    }
});

// GET by ID
router.get('/:id', async (req, res) => {
    try {
        const item = await Item.findById(req.params.id);
        if (!item) return res.status(404).end();
            res.json(item);
    } catch {
        res.status(404).end();
    }
});

module.exports = router; 
```

.env
```.env
PORT=3000
MONGO_URI=mongodb://localhost:27017/myappdb 
```

##### frontend
item-service.ts
```ts
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

export interface Item { _id?: string; name: string; price: number; }

@Injectable({ providedIn: 'root' })
export class ItemService {
  private apiUrl = 'http://localhost:3000/api/items';

  constructor(private http: HttpClient) { }

  getAll(): Observable<Item[]> {
    return this.http.get<Item[]>(this.apiUrl);
  }

  create(item: Item): Observable<Item> {
    return this.http.post<Item>(this.apiUrl, item);
  }
}
```

item-list-component.ts
```ts
import { Component, OnInit } from '@angular/core';
import { ItemService, Item } from '../../services/item.service';
import { FormsModule } from '@angular/forms';


@Component({
  selector: 'app-item-list', 
  standalone: true,
  imports: [FormsModule],
  templateUrl: './item-list.component.html' 
})

export class ItemListComponent implements OnInit {
  items: Item[] = [];
  newItem: Item = { name: '', price: 0 };

  constructor(private itemSvc: ItemService) {}

  ngOnInit(): void {
    this.load();
  }

  load() {
    this.itemSvc.getAll().subscribe(data => this.items = data);
  }

  add() {
    this.itemSvc.create(this.newItem).subscribe(() => {
      this.newItem = { name: '', price: 0 };
      this.load();
    });
  }
}
```

item-list-component.html
```html
<div>
    <h2>Items</h2>
    <ul>
        <li *ngFor="let it of items">{{ it.name }} — ${{ it.price }}</li>
    </ul>

    <h3>Crear nuevo</h3>
    <input placeholder="Nombre" [(ngModel)]="newItem.name">
    <input placeholder="Precio" type="number" [(ngModel)]="newItem.price">
    <button (click)="add()">Agregar</button>
</div> 
```

Dockerfile
```dockerfile
FROM node:22 as build
WORKDIR /app
COPY package*.json ./
RUN npm ci
COPY . . 
RUN npm run build -- --output-path=dist

FROM nginx:alpine
COPY --from=build /app/dist /usr/share/nginx/html 
```

app.config.ts
```ts
import { ApplicationConfig, provideZoneChangeDetection } from '@angular/core';
import { provideClientHydration, withEventReplay } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';
import { importProvidersFrom } from '@angular/core';

export const appConfig: ApplicationConfig = {
  providers: [
    provideZoneChangeDetection({ eventCoalescing: true }), 
    provideClientHydration(withEventReplay()),
    importProvidersFrom(FormsModule) 
  ]
}; 
```

## Desafíos Encontrados

- **Sin impedimentos:** Por el momento no tuve ningún inconveniente al realizar esta actividad.  

## Recursos Adicionales

- Vmware vSphere 8: ESXi y vCenter desde cero a avanzado.
- Introducción a Docker para principiantes.
- Docker, de principiante a experto.
- Curso práctico de Docker y Microservicios (apto para todos).
- Curso completo de Docker de cero a experto.
- Kubernetes al completo.
- Kubernetes para Desarrolladores.

## Próximos Pasos

- Continuar los avances en cursos de Udemy. 
- Practicar los ejercicios realizados en la sesión.

## Reflexiones Personales

Esta sesión me ha ayudado a aprender y recordar temas sobre los contenedores. 

---

*Entregable correspondiente a la Semana 14 del Módulo 4: Kubernetes*