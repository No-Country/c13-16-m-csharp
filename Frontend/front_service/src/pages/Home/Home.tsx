import React from 'react';
import './home.css';
import NavBar from '../../components/NavBar/NavBar';
import Hero from '../../components/Hero/Hero';
import Solution from '../../components/Solution/Solution';
import Blog from '../../components/Blog/Blog';

export default function Home() {
  return (
    <div>
      <NavBar />
      <Hero />
      <Solution />
      <Blog />
    </div>
  )
}
