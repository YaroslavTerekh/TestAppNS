import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AnnoucementItemComponent } from './annoucement-item.component';

describe('AnnoucementItemComponent', () => {
  let component: AnnoucementItemComponent;
  let fixture: ComponentFixture<AnnoucementItemComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AnnoucementItemComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(AnnoucementItemComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
