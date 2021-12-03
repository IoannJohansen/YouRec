import { Routes, Route } from 'react-router-dom';
import MyRecommends from '../Components/MyRecommends/MyRecommends';
import CreateRecommend from '../Components/CreateRecommend/CreateRecommend';
import NoMatch from '../Components/NoMatch/NoMatch';
import Layout from '../Components/Layout/Layout.jsx'
import RecommendsPage from '../Components/Recommends/RecommendsPage';
import LoginForm from '../Components/Login/LoginForm';
import Register from '../Components/Register/RegisterForm'
import RecommendDescriptionPage from '../Components/RecommendDescriptionPage/RecomendDescription';
import GuardedRoute from '../hoc/guardroute';

export default function Router() {

    return (
        <Routes>
            <Route path="/" element={<Layout />}>
                    <Route index path="/Recs" element={<RecommendsPage />} />
                    <Route path="/Recs/:id" element={<RecommendDescriptionPage />} />
                    <Route path="/MyRecs" element={<MyRecommends />} />
                    <Route path="/CreateRec" element={
                        <GuardedRoute>
                            <CreateRecommend />
                        </GuardedRoute>} />
                    <Route path="/SignIn" element={<LoginForm />} />
                    <Route path="/Register" element={<Register />} />

                    <Route path="*" element={<NoMatch />} />
            </Route>
        </Routes>
    );
}