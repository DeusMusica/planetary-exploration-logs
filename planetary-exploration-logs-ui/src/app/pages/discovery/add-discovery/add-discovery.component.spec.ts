import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddDiscoveryComponent } from './add-discovery.component';

describe('AddDiscoveryComponent', () => {
  let component: AddDiscoveryComponent;
  let fixture: ComponentFixture<AddDiscoveryComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [AddDiscoveryComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(AddDiscoveryComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
