import React from 'react';
import './home.css';
import NavBar from '../../components/NavBar/NavBar';
import Hero from '../../components/Hero/Hero';
import Solution from '../../components/Solution/Solution';
import Blog from '../../components/Blog/Blog';
import Menu from '../../components/Menu/Menu.tsx'
import { useSelector } from 'react-redux/es/hooks/useSelector';

export default function Home() {
  const menuState = useSelector((store:any) => store.menuReducer.state)
 
  return (
    <div>
      <NavBar />
      <Hero />
      <Solution />
      <Blog />
      {
        menuState ? <Menu/> : <></>
      }
    </div>
  )
}
