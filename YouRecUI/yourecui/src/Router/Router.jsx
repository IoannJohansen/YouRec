import { Routes, Route } from 'react-router-dom';
import MyRecommends from '../Components/MyRecommends/MyRecommends';
import Recommends from '../Components/Recommends/Recommends';
import { createBrowserHistory } from 'history'
import CreateRecommend from '../Components/CreateRecommend/CreateRecommend';

export default function Router() {
    const history = createBrowserHistory();

    return (
        <Routes history={history}>
            <Route path="/Recs" element={<Recommends />} />
            <Route path="/MyRecs" element={<MyRecommends />} />
            <Route path="/CreateRec" element={<CreateRecommend />} />

            
        </Routes>
    );
}