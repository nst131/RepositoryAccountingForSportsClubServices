import {   Directive,   Input,   IterableDiffers,   NgIterable,   OnChanges,   SimpleChanges,   TemplateRef,   ViewContainerRef } from "@angular/core";

import { NgForOf } from "@angular/common";

export interface Selectable<T> {   selected: boolean;   isActive: boolean; }

@Directive({   
 selector: "[optionsFor][[optionsForOf]]" }) 
 export class OptionsForDirective<T extends Selectable<any>,U extends NgIterable<T> = NgIterable<T>> 
     extends NgForOf<T, U> implements OnChanges {   

   _editMode = false;   
   _forOf!: Array<Selectable<any>>;

  @Input()   
  set iefOptionsForOf(value: any) {
    this._forOf = value;
    console.log("set of: ", value);   
  }

  @Input()   
  set iefOptionsForEditMode(value: boolean) {
    this._editMode = value;
    console.log("set edit mode: ", value);   
  }

  constructor(
    public _viewContainer2: ViewContainerRef,
    public _templateRef2: TemplateRef<any>,
    public _differs2: IterableDiffers   ) {
    super(_viewContainer2, _templateRef2, _differs2);   
  }

  ngOnChanges(changes: SimpleChanges) {
    if (changes['optionsForOf']) {
      const origNgForOf: Array<Selectable<any>> = this._forOf;
      let filtered = origNgForOf;
      if (origNgForOf) {
        filtered = origNgForOf.filter(s => {
          return this._editMode || s.isActive !== false;
        });
      }
      console.log("filtered", filtered);

      super.ngForOf = filtered as any;
    }   
  } 
}