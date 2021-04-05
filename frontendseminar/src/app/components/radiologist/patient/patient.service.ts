import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Subject } from 'rxjs';
import { Patient } from '../shared/models/patient.model';
import { TreatmentType } from '../shared/models/treatment-type.model';
import { Treatment } from '../shared/models/treatment.model';

@Injectable({
  providedIn: 'root',
})
export class PatientService {
  patientsChanged = new Subject<Patient>();
  treatmentsChanged = new Subject<Treatment>();

  baseUrl = 'http://localhost:5000/';

  constructor(private http: HttpClient) {}

  getPatients(): Promise<Patient[]> {
    return this.http
      .get<Patient[]>(this.baseUrl + 'api/patients')
      .toPromise()
      .then((data) => {
        return data;
      });
  }

  getTreatmentTypes(): Promise<TreatmentType[]> {
    return this.http
      .get<TreatmentType[]>(this.baseUrl + 'api/treatmenttypes')
      .toPromise()
      .then((data) => {
        return data;
      });
  }

  getPatient(id: number): Promise<Patient> {
    return this.http
      .get<Patient>(this.baseUrl + `api/patients/${id}`)
      .toPromise()
      .then((data) => {
        return data;
      });
  }

  getTreatments(patientId: number) {
    return this.http
      .get<Treatment[]>(this.baseUrl + `api/treatments/patient/${patientId}`)
      .toPromise()
      .then((data) => data);
  }

  getTreatmentsTotalCost(patientId: number): number {
    let totalCost = 0;
    this.http
      .get<{ value: number }>(
        this.baseUrl + `api/treatments/patient/${patientId}/totalcost`
      )
      .toPromise()
      .then((data) => {
        totalCost = data.value;
      });

    return totalCost;
  }

  createPatient(patient: Patient): void {
    this.http
      .post<Patient>(this.baseUrl + 'api/patients', patient)
      .subscribe((result) => {
        this.patientsChanged.next(result);
      });
  }

  craeteTreatment(treatment: Treatment): void {
    this.http
      .post<Treatment>(this.baseUrl + 'api/treatments', treatment)
      .subscribe((result) => {
        this.treatmentsChanged.next(result);
      });
  }

  editPatient(id: number, patient: Patient) {
    this.http
      .put<Patient>(this.baseUrl + `api/patients/${id}`, patient)
      .subscribe((result) => {
        console.log(result);
        this.patientsChanged.next(result);
      });
  }

  editTreatment(id: number, treatment: Treatment) {
    console.log(treatment);
    this.http
      .put<Treatment>(this.baseUrl + `api/treatments/${id}`, treatment)
      .subscribe((result) => {
        this.treatmentsChanged.next(result);
      });
  }

  deletePatient(id: number) {
    this.http.delete(this.baseUrl + `api/patients/${id}`).subscribe();
  }

  deleteTreatment(id: number) {
    this.http.delete(this.baseUrl + `api/treatments/${id}`).subscribe();
  }
}
