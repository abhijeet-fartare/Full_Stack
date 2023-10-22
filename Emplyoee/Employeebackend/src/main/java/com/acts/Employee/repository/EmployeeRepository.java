package com.acts.Employee.repository;

import java.util.Optional;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

import com.acts.Employee.entity.Employee;

@Repository
public interface EmployeeRepository extends JpaRepository<Employee, Long> {


}
