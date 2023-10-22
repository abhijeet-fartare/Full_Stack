package com.acts.Employee.controller;

import java.util.List;
import java.util.Optional;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.CrossOrigin;
import org.springframework.web.bind.annotation.DeleteMapping;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.PutMapping;
import org.springframework.web.bind.annotation.RequestBody;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;

import com.acts.Employee.entity.Employee;
import com.acts.Employee.repository.EmployeeRepository;

@RestController
@RequestMapping("/api/")
@CrossOrigin("*")
public class EmployeeController {

	@Autowired
	private EmployeeRepository employeeRepository;

	@GetMapping("/employees")
	public List<Employee> getAllEmp() {
		return employeeRepository.findAll();
	}

	@PostMapping("/employees")
	public Employee createEmp(@RequestBody Employee employee) {
		return employeeRepository.save(employee);
	}

	@GetMapping("/employees/{id}")
	public Optional<Employee> getEmpById(@PathVariable Long id) {
		return employeeRepository.findById(id);
	}

	@PutMapping("/employees/{id}")
	public Employee updateEmp(@PathVariable Long id, @RequestBody Employee employee) {
		Employee emp = employeeRepository.findById(id).orElseThrow();
		emp.setFirstName(employee.getFirstName());
		emp.setLastName(employee.getLastName());
		emp.setEmailId(employee.getEmailId());
		Employee updatedemp = employeeRepository.save(emp);
		return updatedemp;
	}

	@DeleteMapping("/employees/{id}")
	public void deleteEmp(@PathVariable Long id) {
		employeeRepository.deleteById(id);
	}
}
