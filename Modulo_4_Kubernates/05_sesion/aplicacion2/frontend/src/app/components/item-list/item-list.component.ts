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