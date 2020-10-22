import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddEditKorisnikComponent } from './add-edit-korisnik.component';

describe('AddEditKorisnikComponent', () => {
  let component: AddEditKorisnikComponent;
  let fixture: ComponentFixture<AddEditKorisnikComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AddEditKorisnikComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AddEditKorisnikComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
